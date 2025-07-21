using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.DTOs.response
{
    public class SurveyPointRes
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

        public virtual LocationDesDto? LocationDesDto { get; set; }
        public virtual VegetationCoverDto? VegetationCoverDto { get; set; }
        public virtual HydrologyDto? HydrologyDto { get; set; }
    }

    public class LocationDesDto
    {
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
    }

    public class VegetationCoverDto
    {
        [Column("grass_percentage", TypeName = "decimal(5,2)")]
        public decimal? GrassPercentage { get; set; }

        [Column("soil_percentage", TypeName = "decimal(5,2)")]
        public decimal? SoilPercentage { get; set; }

        [Column("forest_percentage", TypeName = "decimal(5,2)")]
        public decimal? ForestPercentage { get; set; }

        [Column("crop_percentage", TypeName = "decimal(5,2)")]
        public decimal? CropPercentage { get; set; }

        [Column("other", TypeName = "decimal(5,2)")]
        public decimal? Other { get; set; }

        [Column("natural_forest_percentage", TypeName = "decimal(5,2)")]
        public decimal? NaturalForestPercentage { get; set; }

        [Column("flower_percentage", TypeName = "decimal(5,2)")]
        public decimal? FlowerPercentage { get; set; }
    }

    public class HydrologyDto
    {

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
    }
}
