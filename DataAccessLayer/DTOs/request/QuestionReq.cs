using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.DTOs.request
{
    public class QuestionReq
    {
        [Required]
        public int GroupId { get; set; }

        [Required]
        [StringLength(500)]
        public string QuestionText { get; set; } = null!;

        [Required]
        [StringLength(1000)]
        public string AnswerText { get; set; } = null!;
    }
}
