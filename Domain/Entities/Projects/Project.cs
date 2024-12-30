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
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "DECIMAL(10,2)")]
        public decimal TotalHours { get; set; }

        [DefaultValue(0)]
        [Column(TypeName = "DECIMAL(10,2)")]
        public decimal? ConsumedHours { get; set; } = 0;

        [Column(TypeName = "DATE")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "DATE")]
        public DateTime? EndDate { get; set; }

        public int? EstimatedDevelopmentHours { get; set; }

        [Column(TypeName = "FLOAT")]
        public decimal? Budget { get; set; }

        public int? ResponsiblePerson { get; set; }

        [ForeignKey("Client")]
        public long? ClientId { get; set; }

        public byte? Status { get; set; }

        public int? CreatedBy { get; set; }

        [Required]
        [Column(TypeName = "DATETIME")]
        public DateTime LastUpdated { get; set; }

        // Navigation property for the foreign key relationship
        public virtual Client? Client { get; set; }
    }
}
