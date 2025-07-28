using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Models
{
    public class PhoGammaDevice : MeasuringDevice
    {
        public double? K { get; set; }
        public double? U { get; set; }
        public double? Th { get; set; }
        public PhoGammaDevice() => Type = DeviceType.PhoGamma;
    }
}