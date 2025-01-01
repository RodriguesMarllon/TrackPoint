using FluentValidation;

namespace Application.Handlers.WorkLogs.Queries.Delete
{
    public class DeleteWorkLogQueryValidator : AbstractValidator<DeleteWorkLogQueryRequest>
    {
        public DeleteWorkLogQueryValidator()
        {
        }
    }
}
