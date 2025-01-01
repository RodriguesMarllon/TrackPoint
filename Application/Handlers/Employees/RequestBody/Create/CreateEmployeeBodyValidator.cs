using FluentValidation;

namespace Application.Handlers.Employees.RequestBody.Create
{
    public class CreateEmployeeBodyValidator : AbstractValidator<CreateEmployeeBodyRequest>
    {
        public CreateEmployeeBodyValidator()
        {
        }
    }
}
