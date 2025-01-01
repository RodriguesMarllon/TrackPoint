using Application.Models.Abstracts;
using Application.Models.Response.WorkLog;
using FluentValidation;

namespace Application.Handlers.WorkLogs.RequestBody.Update
{
    public class UpdateWorkLogBodyValidator : AbstractValidator<ResponseBase<UpdateWorkLogResponseItem>>
    {
        public UpdateWorkLogBodyValidator()
        {
        }
    }
}
