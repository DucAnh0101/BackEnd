using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Models
{
    public class LocationDescription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("SurveyPoint")]
        [Column("survey_point_id")]
        public int SurveyPointId { get; set; }

        [MaxLength(100)]
        [Column("survey_point_type")]
        public string? SurveyPointType { get; set; }

        [Column("population_density", TypeName = "decimal(10,2)")]
        public decimal? PopulationDensity { get; set; }

        [MaxLength(500)]
        [Column("location_description")]
        public string? Description { get; set; }

        [MaxLength(500)]
        [Column("infrastructure")]
        public string? Infrastructure { get; set; }

        [MaxLength(100)]
        [Column("residents")]
        public string? Residents { get; set; }

        public virtual SurveyPoint SurveyPoint { get; set; }
    }
}
