using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Models
{
    public class XrfDevice : MeasuringDevice
    {
        public string Note { get; set; }
        public XrfDevice() => Type = DeviceType.Xrf;
    }
}