using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Week1_WebApi.Data;

namespace Week1_WebApi.Filters
{
    public class NotFoundFilter : ActionFilterAttribute
    {
        private readonly List<Student> _context;
        public NotFoundFilter()
        {
            _context = SeedData.GetAllStudents();
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionDescriptor.Parameters.Any(x => x.Name == "id"))
            {
                int id = (int)(context.ActionArguments.Values.First());

                if (!_context.Any(x => x.Id == id))
                {
                    context.Result = new ObjectResult(new ErrorResponse(Messages.GetError));
                };
            }
        }
    }
}
