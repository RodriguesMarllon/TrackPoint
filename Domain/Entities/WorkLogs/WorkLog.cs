using Domain.Entities.Activitys;
using Domain.Entities.Employees;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace Domain.Entities.WorkLogs
{
    public class WorkLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public long Id { get; set; }

        [Required]
        [Column("ActivityId")]
        public long ActivityId { get; set; }

        [Required]
        [Column("EmployeeId")]
        public long EmployeeId { get; set; }

        [Required]
        [Column("EntryDateTime")]
        public DateTime EntryDateTime { get; set; }

        [Column("ExitDateTime")]
        public DateTime? ExitDateTime { get; set; }

        [Column("Break")]
        [MaxLength(8)]
        public string? Break { get; set; }

        [Column("WorkHours")]
        [Range(0.0, double.MaxValue)]
        public float WorkHours { get; set; } = 0.000000f;

        [Column("DayType")]
        public byte DayType { get; set; } = 0;

        [Column("Description")]
        [MaxLength(1000)]
        public string? Description { get; set; }

        [Required]
        [Column("Status")]
        public byte Status { get; set; } = 0;

        [Column("Transport")]
        public string? Transport { get; set; }

        [Column("Expenses")]
        public string? Expenses { get; set; }

        [Column("ValidationResponsible")]
        public string? ValidationResponsible { get; set; }

        [Required]
        [Column("InsertUpdateDate")]
        public DateTime InsertUpdateDate { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public virtual Activity? Activity { get; set; }
        public virtual Employee? Employee { get; set; }
    }
}
