using BusiniessObject.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Models
{
    public class GammaCalibration : BaseEntity
    {
        public double RangeValue { get; set; }
        public double Coefficient { get; set; }
        public int GammaDeviceId { get; set; }
        public GammaDevice GammaDevice { get; set; }
    }
}