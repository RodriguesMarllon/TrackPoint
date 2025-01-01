using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Employees
{
    public class Employee
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string Email { get; set; }


        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string Address { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string Phone { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string Signature { get; set; }

        public bool Active { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string Position { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public DateTime DateInsertUpdate { get; set; }
    }
}
