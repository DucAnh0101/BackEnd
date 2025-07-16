using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Models
{
    public class GammaCalibration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public Double Khoang { get; set; }

        [Required]
        public Double HeSoChuanMay { get; set; }

        [Required]
        public int MeasuringDeviceId { get; set; }

        public MeasuringDevice MeasuringDevice { get; set; } = null!;
    }
}