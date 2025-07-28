using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusiniessObject.Models
{
    public class GammaDevice : MeasuringDevice
    {
        public List<GammaCalibration> Calibrations { get; set; } = new();
        public GammaDevice() => Type = DeviceType.Gamma;
    }
}
