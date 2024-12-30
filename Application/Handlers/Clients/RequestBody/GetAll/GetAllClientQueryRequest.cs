using Application.Models.Abstracts;
using Application.Models.Response.Clients;
using MediatR;
using System.Diagnostics.CodeAnalysis;

namespace Application.Handlers.Clients.RequestBody.GetAll
{
    [ExcludeFromCodeCoverage]
    public class GetAllClientQueryRequest : IRequest<ResponseBase<List<GetAllClientResponseItem>>>
    {
    }
}
