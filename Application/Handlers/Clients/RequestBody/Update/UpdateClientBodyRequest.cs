using Application.Models.Abstracts;
using Application.Models.Response.Clients;
using MediatR;

namespace Application.Handlers.Clients.RequestBody.Update
{
    public class UpdateClientBodyRequest : IRequest<ResponseBase<UpdateClientResponseItem>>
    {
        public long Id { get; set; }
        public string CNPJ { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public byte[] Logo { get; set; }
    }
}
