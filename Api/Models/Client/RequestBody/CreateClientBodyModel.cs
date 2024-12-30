using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.Models.Client.RequestBody
{
    public class CreateClientBodyModel
    {
        public string Name { get; set; }
        public string CNPJ { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public byte[]? Logo { get; set; }
    }
}
