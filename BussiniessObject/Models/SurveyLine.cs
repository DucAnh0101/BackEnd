using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Models
{
    public enum SurveyLineStatus { Investigation, Evaluation }

    [Table("SurveyLines")]
    public class SurveyLine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SlId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        public SurveyLineStatus Status { get; set; }

        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal CompletionPercentage { get; set; }

        [Required]
        [Column("is_delete")]
        public bool IsDelete { get; set; } = false;

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }
        public virtual ICollection<SurveyPoint> SurveyPoints { get; set; } = new List<SurveyPoint>();
    }

}