using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Models
{
    public class GammaInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int MeasuringDeviceId { get; set; }

        public virtual MeasuringDevice MeasuringDevice { get; set; }

        public virtual ICollection<GammaCalibration> Calibrations { get; set; } = new List<GammaCalibration>();
    }
}