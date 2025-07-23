using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Models
{
    [Table("Projects")]
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PrId { get; set; }

        [Required]
        [MaxLength(200)]
        public string? Name { get; set; }

        [Required]
        public DateOnly CreatedDate { get; set; }

        [Required]
        public DateOnly EndDate { get; set; }

        [Required]
        [Column("is_delete")]
        public bool IsDelete { get; set; } = false;

        [Required]
        [ForeignKey("Proposal")]
        public int ProposalId { get; set; }

        public virtual Proposal? Proposal { get; set; }
        public virtual ICollection<SurveyLine> SurveyLines { get; set; } = new List<SurveyLine>();
    }

}