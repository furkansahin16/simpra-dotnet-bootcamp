using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Week1_WebApi.Data;
using Week1_WebApi.FluentValidators;

namespace Week1_WebApi.Controllers;

[NotFoundFilter]
[CustomValidate(typeof(StudentValidator))]
public class StudentsController : BaseApiController
{
    private readonly List<Student> _students;
    public StudentsController(IValidator<Student> validator)
    {
        _students = SeedData.GetAllStudents();
    }

    [HttpGet]
    public ICommonResponse GetStudents(string? pageNumber, string? pageSize)
    {
        int pageNumberInt = int.TryParse(pageNumber, out var parsedPageNumber) && parsedPageNumber > 0 ? parsedPageNumber : 1;
        int pageSizeInt = int.TryParse(pageSize, out var parsedPageSize) && parsedPageSize > 0 ? parsedPageSize : 5;

        var studentList = GetListData(pageNumberInt, pageSizeInt);

        return studentList.Any()
            ? new SuccessDataResponse<List<Student>>(studentList, Messages.ListSuccess)
            : new ErrorResponse(Messages.ListError);
    }

    [HttpGet("{id}")]
    public ICommonResponse GetStudentById(int id)
    {
        var student = _students.First(x => x.Id == id);

        return new SuccessDataResponse<Student>(student, Messages.GetSuccess);
    }

    [HttpDelete]
    public ICommonResponse Delete(int id)
    {
        var student = _students.First(x => x.Id == id);
        _students.Remove(student);
        return new SuccessDataResponse<Student>(student, Messages.DeleteSuccess);
    }

    [HttpPost]
    public ICommonResponse AddStudent([FromBody] Student model)
    {
        _students.Add(model);
        return new SuccessDataResponse<Student>(model, Messages.AddSuccess);
    }

    [HttpPut("{id}")]
    public ICommonResponse UpdateStudent(int id, [FromBody] Student model)
    {
        var student = _students.First(x => x.Id == id);
        _students.Remove(student);
        _students.Add(model);
        return new SuccessDataResponse<Student>(model, Messages.UpdateSuccess);
    }

    private List<Student> GetListData(int pageNumber = 1, int pageSize = 2)
    {
        return _students.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
    }

}
