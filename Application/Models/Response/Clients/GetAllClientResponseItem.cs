using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Response.Clients
{
    public class GetAllClientResponseItem
    {
        public long Id { get; set; }
        public string CNPJ { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
    }
}
