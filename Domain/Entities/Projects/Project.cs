using Domain.Entities.Clients;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Projects
{
    public class Project
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [ForeignKey("Client")]
        public long ClientId { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(10,2)")]
        public decimal TotalHours { get; set; }

        [DefaultValue(0)]
        [Column(TypeName = "DECIMAL(10,2)")]
        public decimal? ConsumedHours { get; set; } = 0;

        public string? Description { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        // Navigation property for Client
        public virtual Client? Client { get; set; }
    }
}
