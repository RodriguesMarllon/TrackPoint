using FluentValidation;

namespace Application.Handlers.Projects.Queries.GetAll
{
    public class GetAllProjectQueryValidator : AbstractValidator<GetAllProjectQueryRequest>
    {
        public GetAllProjectQueryValidator()
        {
        }
    }
}
