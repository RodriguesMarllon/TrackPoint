using FluentValidation;

namespace Application.Handlers.Clients.RequestBody.Update
{
    public class UpdateClientBodyValidator : AbstractValidator<UpdateClientBodyRequest>
    {
        public UpdateClientBodyValidator() 
        {
        }
    }
}
