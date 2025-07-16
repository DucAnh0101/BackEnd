using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs.request
{
   public class GammaDeviceRequest
    {
        public string SerialNumber { get; set; }
        public List<GammaCalibrationDto> Calibrations { get; set; }
    }
}
