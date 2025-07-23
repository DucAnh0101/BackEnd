using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Models
{
    [Table("Proposals")]
    public class Proposal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        public DateOnly CreatedDate { get; set; }

        [Required]
        public DateOnly EndDate { get; set; }

        [Required]
        [Column("is_delete")]
        public bool IsDelete { get; set; } = false;

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
    }

}