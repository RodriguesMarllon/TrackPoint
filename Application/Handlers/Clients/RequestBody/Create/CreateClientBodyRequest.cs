using Application.Models.Abstracts;
using Application.Models.Response.Clients;
using MediatR;

namespace Application.Handlers.Clients.RequestBody.Create
{
    public class CreateClientBodyRequest : IRequest<ResponseBase<CreateClientResponseItem>>
    {
        public string Name { get; set; }
        public string CNPJ { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public byte[]? Logo { get; set; }
    }
}
