using FluentValidation;

namespace Application.Handlers.Employees.RequestBody.Update
{
    public class UpdateEmployeeBodyValidator : AbstractValidator<UpdateEmployeeBodyRequest>
    {
        public UpdateEmployeeBodyValidator() 
        {
        }
    }
}
