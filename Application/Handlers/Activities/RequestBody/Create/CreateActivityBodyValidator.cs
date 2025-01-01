using FluentValidation;

namespace Application.Handlers.Activities.RequestBody.Create
{
    public class CreateActivityBodyValidator : AbstractValidator<CreateActivityBodyRequest>
    {
        public CreateActivityBodyValidator()
        {
        }
    }
}
