using Application.Models.Abstracts;
using Application.Models.Response.Clients;
using MediatR;
using System.Diagnostics.CodeAnalysis;

namespace Application.Handlers.Clients.Queries.GetAll
{
    [ExcludeFromCodeCoverage]
    public class GetAllClientQueryRequest : IRequest<ResponseBase<List<GetAllClientResponseItem>>>
    {
    }
}
