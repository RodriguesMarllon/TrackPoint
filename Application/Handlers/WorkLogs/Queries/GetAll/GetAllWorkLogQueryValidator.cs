using FluentValidation;

namespace Application.Handlers.WorkLogs.Queries.GetAll
{
    public class GetAllWorkLogQueryValidator : AbstractValidator<GetAllWorkLogQueryRequest>
    {
        public GetAllWorkLogQueryValidator()
        {
        }
    }
}
