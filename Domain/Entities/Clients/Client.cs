using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Clients
{
    public class Client
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string Name { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string? Email { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string? Phone { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string? Address { get; set; }
    }
}
