using FluentValidation;

namespace Application.Handlers.WorkLogs.RequestBody.Create
{
    public class CreateWorkLogBodyValidator : AbstractValidator<CreateWorkLogBodyRequest>
    {
        public CreateWorkLogBodyValidator()
        {
        }
    }
}
