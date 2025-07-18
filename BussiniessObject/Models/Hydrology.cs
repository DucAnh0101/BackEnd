using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Models
{
    [Table("Hydrologies")]
    public class Hydrology
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("SurveyPoint")]
        [Column("survey_point_id")]
        public int SurveyPointId { get; set; }

        [Required]
        [Column("water_presence")]
        public bool WaterPresence { get; set; }

        [Column("water_level", TypeName = "decimal(8,2)")]
        public decimal? WaterLevel { get; set; }

        [Column("water_flow", TypeName = "decimal(8,2)")]
        public decimal? WaterFlow { get; set; }

        [Column("distance_to_water_source", TypeName = "decimal(8,2)")]
        public decimal? DistanceToWaterSource { get; set; }

        [MaxLength(500)]
        [Column("water_source_features")]
        public string? WaterSourceFeatures { get; set; }

        [MaxLength(100)]
        [Column("surface_water_type")]
        public string? SurfaceWaterType { get; set; }

        [Column("surface_water_level", TypeName = "decimal(8,2)")]
        public decimal? SurfaceWaterLevel { get; set; }

        [Column("surface_water_flow", TypeName = "decimal(8,2)")]
        public decimal? SurfaceWaterFlow { get; set; }

        [Column("surface_water_distance", TypeName = "decimal(8,2)")]
        public decimal? SurfaceWaterDistance { get; set; }

        [MaxLength(500)]
        [Column("surface_water_features")]
        public string? SurfaceWaterFeatures { get; set; }

        public virtual SurveyPoint SurveyPoint { get; set; }
    }
}
