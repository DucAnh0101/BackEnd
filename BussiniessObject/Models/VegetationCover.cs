using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Models
{
    [Table("VegetationCovers")]
    public class VegetationCover
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("SurveyPoint")]
        [Column("survey_point_id")]
        public int SurveyPointId { get; set; }

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

        public virtual SurveyPoint SurveyPoint { get; set; }
    }
}