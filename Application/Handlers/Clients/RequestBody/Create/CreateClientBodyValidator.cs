using FluentValidation;

namespace Application.Handlers.Clients.RequestBody.Create
{
    public class CreateClientBodyValidator : AbstractValidator<CreateClientBodyRequest>
    {
        public CreateClientBodyValidator()
        {
        }
    }
}
