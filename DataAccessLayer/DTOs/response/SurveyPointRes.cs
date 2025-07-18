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
    }
}
