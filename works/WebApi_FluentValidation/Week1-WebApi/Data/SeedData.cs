using System.Reflection.Metadata.Ecma335;

namespace Week1_WebApi.Data;

public static class SeedData
{
    private static List<Student> _students = new List<Student>()
        {
            new(1,"Furkan","furkan@mail.com","5555555555"),
            new(2,"Furkan2","furkan@mail.com","5555555555"),
            new(3,"Furkan3","furkan@mail.com","5555555555"),
            new(4,"Furkan4","furkan@mail.com","5555555555"),
            new(5,"Furkan5","furkan@mail.com","5555555555"),
        };

    public static List<Student> GetAllStudents() => _students;
}
