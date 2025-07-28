using BusiniessObject.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Models
{
    public abstract class MeasuringDevice : BaseEntity
    {
        public string SerialNumber { get; set; }
        public DeviceType Type { get; set; }
    }
}