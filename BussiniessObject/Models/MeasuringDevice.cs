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

        public virtual DeviceType DeviceType { get; set; }

        public virtual GammaInfo GammaInfo { get; set; }
        public virtual PhoGammaInfo PhoGammaInfo { get; set; }
        public virtual XRFInfo XRFInfo { get; set; }
    }
}