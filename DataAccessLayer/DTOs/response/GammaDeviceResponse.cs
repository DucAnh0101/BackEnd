using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs.response
{
    public class GammaDeviceResponse
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public List<GammaCalibrationDto> Calibrations { get; set; }
    }
}
