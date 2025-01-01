using FluentValidation;

namespace Application.Handlers.Clients.Queries.GetAll
{
    public class GetAllClientQueryValidator : AbstractValidator<GetAllClientQueryRequest>
    {
        public GetAllClientQueryValidator()
        {
        }
    }
}
