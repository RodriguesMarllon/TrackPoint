using Application.Models.Abstracts;
using Application.Models.Response.WorkLog;
using MediatR;

namespace Application.Handlers.WorkLogs.Queries.Delete
{
    public class DeleteWorkLogQueryRequest : IRequest<ResponseBase<DeleteWorkLogResponseItem>>
    {
        public long Id { get; set; }
    }
}
