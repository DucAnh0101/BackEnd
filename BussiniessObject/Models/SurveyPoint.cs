using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Models
{
    [Table("SurveyPoints")]
    public class SurveyPoint
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        [Required]
        [Column("is_active")]
        public bool IsActive { get; set; } = true;

        [Required]
        [ForeignKey("User")]
        [Column("user_id")]
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual LocationDescription? LocationDescription { get; set; }
        public virtual VegetationCover? VegetationCover { get; set; }
        public virtual Hydrology? Hydrology { get; set; }
    }
}