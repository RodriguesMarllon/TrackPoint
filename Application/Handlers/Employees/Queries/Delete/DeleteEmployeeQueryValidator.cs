using FluentValidation;

namespace Application.Handlers.Employees.Queries.Delete
{
    public class DeleteEmployeeQueryValidator : AbstractValidator<DeleteEmployeeQueryRequest>
    {
        public DeleteEmployeeQueryValidator()
        {
        }
    }
}
