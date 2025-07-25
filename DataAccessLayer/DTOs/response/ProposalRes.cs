using BusinessObject.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.DTOs.response
{
    public class ProposalRes
    {
        public int PId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        public DateOnly CreatedDate { get; set; }

        [Required]
        public DateOnly EndDate { get; set; }

        public virtual ICollection<ProjectRes> ProjectRes { get; set; } = new List<ProjectRes>();
    }

    public class ProjectRes
    {
        public int PrId { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        public DateOnly CreatedDate { get; set; }

        public DateOnly EndDate { get; set; }

        public virtual ICollection<SurveyLineRes> SurveyLines { get; set; } = new List<SurveyLineRes>();
    }

    public class SurveyLineRes
    {
        public int SlId { get; set; }

        public string Name { get; set; }

        public SurveyLineStatus Status { get; set; }

        public decimal CompletionPercentage { get; set; }

        public bool IsDelete { get; set; } = false;

        public DateOnly CreatedDate { get; set; }

        public virtual ICollection<SurveyPointReturn> SurveyPoints { get; set; } = new List<SurveyPointReturn>();
    }

    public class ProjectSearchRes
    {
        public string Name { get; set; }

        public DateOnly CreatedDate { get; set; }

        public DateOnly EndDate { get; set; }

        public SurveyLineStatus Status { get; set; }

        public decimal CompletionPercentage { get; set; }

        public DateOnly PrCreatedDate { get; set; }
    }

    public class SurveyPointReturn
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        [Column("survey_name")]
        public string SurveyName { get; set; }

        [Required]
        [Column("latitude", TypeName = "decimal(10,8)")]
        public decimal Latitude { get; set; }

        [Required]
        [Column("longitude", TypeName = "decimal(11,8)")]
        public decimal Longitude { get; set; }

        [Required]
        [Column("altitude", TypeName = "decimal(8,2)")]
        public decimal? Altitude { get; set; }

        [MaxLength(1000)]
        [Column("address")]
        public string? Address { get; set; }
    }
}
