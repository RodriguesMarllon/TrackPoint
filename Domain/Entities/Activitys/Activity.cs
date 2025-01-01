using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Activitys
{
    public class Activity
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        public bool External { get; set; }
    }
}
