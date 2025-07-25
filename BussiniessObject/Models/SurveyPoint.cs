using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Models
{
    [Table("SurveyPoints")]
    public class SurveyPoint
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SpId { get; set; }

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

        [Column("altitude", TypeName = "decimal(8,2)")]
        public decimal? Altitude { get; set; }

        [MaxLength(1000)]
        [Column("address")]
        public string? Address { get; set; }

        [Required]
        [Column("is_delete")]
        public bool IsDelete { get; set; } = false;

        [Required]
        [Column("created_date")]
        public DateOnly CreatedDate { get; set; }

        [Required]
        [ForeignKey("SurveyLine")]
        [Column("survey_line_id")]
        public int SurveyLineId { get; set; }

        public virtual SurveyLine SurveyLine { get; set; }
        public virtual LocationDescription? LocationDescription { get; set; }
        public virtual VegetationCover? VegetationCover { get; set; }
        public virtual Hydrology? Hydrology { get; set; }
    }

}