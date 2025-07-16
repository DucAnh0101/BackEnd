using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Models
{
    public class MeasuringDevice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string SerialNumber { get; set; }

        [Required]
        public int DeviceTypeId { get; set; }

        public DeviceType DeviceType { get; set; } = null!;
        public ICollection<GammaCalibration> GammaCalibrations { get; set; } = new List<GammaCalibration>();
        public ICollection<PhoGammaInfo> PhoGammaInfos { get; set; } = new List<PhoGammaInfo>();
        public ICollection<XRFInfo> XRFInfos { get; set; } = new List<XRFInfo>();
    }
}