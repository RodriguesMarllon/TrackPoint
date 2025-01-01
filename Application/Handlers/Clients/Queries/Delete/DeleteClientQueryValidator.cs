using FluentValidation;

namespace Application.Handlers.Clients.Queries.Delete
{
    public class DeleteClientQueryValidator : AbstractValidator<DeleteClientQueryRequest>
    {
        public DeleteClientQueryValidator() 
        {
        }
    }
}
