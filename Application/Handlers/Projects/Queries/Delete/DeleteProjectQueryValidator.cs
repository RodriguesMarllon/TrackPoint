using FluentValidation;

namespace Application.Handlers.Projects.Queries.Delete
{
    public class DeleteProjectQueryValidator : AbstractValidator<DeleteProjectQueryRequest>
    {
        public DeleteProjectQueryValidator() 
        {
        }
    }
}
