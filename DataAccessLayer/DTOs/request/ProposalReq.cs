using BusinessObject.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.DTOs.request
{
    public class ProposalReq
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        public DateOnly CreatedDate { get; set; }

        [Required]
        public DateOnly EndDate { get; set; }
    }

    public class ProjectReq
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        public DateOnly CreatedDate { get; set; }

        [Required]
        public DateOnly EndDate { get; set; }
    }

    public class SurveyLineReq
    {

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
    }
}
