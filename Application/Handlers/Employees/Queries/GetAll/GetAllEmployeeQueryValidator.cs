using FluentValidation;

namespace Application.Handlers.Employees.Queries.GetAll
{
    public class GetAllEmployeeQueryValidator : AbstractValidator<GetAllEmployeeQueryRequest>
    {
        public GetAllEmployeeQueryValidator()
        {
        }
    }
}
