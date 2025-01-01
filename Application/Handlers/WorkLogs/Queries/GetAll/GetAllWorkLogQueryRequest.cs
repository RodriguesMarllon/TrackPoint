using Application.Models.Abstracts;
using Application.Models.Response.WorkLog;
using MediatR;
using System.Diagnostics.CodeAnalysis;

namespace Application.Handlers.WorkLogs.Queries.GetAll
{
    [ExcludeFromCodeCoverage]
    public class GetAllWorkLogQueryRequest : IRequest<ResponseBase<List<GetAllWorkLogResponseItem>>>
    {
    }
}
