using Application.Models.Abstracts;
using Application.Models.Response.Clients;
using MediatR;

namespace Application.Handlers.Clients.Queries.Delete
{
    public class DeleteClientQueryRequest : IRequest<ResponseBase<DeleteClientResponseItem>>
    {
        public long Id { get; set; }
    }
}
