using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Models
{
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int GroupId { get; set; }

        [Required]
        [MaxLength(500)]
        public string QuestionText { get; set; }

        [Required]
        [MaxLength(1000)]
        public string AnswerText { get; set; }

        public virtual QuestionGroup Group { get; set; }
    }
}