using FluentValidation;

namespace Application.Handlers.Projects.RequestBody.Create
{
    public class CreateProjectBodyValidator : AbstractValidator<CreateProjectBodyRequest>
    {
        public CreateProjectBodyValidator() 
        {
        }
    }
}
