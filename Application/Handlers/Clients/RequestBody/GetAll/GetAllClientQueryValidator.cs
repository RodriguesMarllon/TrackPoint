using FluentValidation;

namespace Application.Handlers.Clients.RequestBody.GetAll
{
    public class GetAllClientQueryValidator : AbstractValidator<GetAllClientQueryRequest>
    {
        public GetAllClientQueryValidator()
        {
        }
    }
}
