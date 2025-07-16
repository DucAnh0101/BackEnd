using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs.request
{
    public class MeasuringDeviceDto
    {
        public string SerialNumber { get; set; }
        public int DeviceTypeId { get; set; }

        public GammaInfoDto GammaInfo { get; set; }
        public PhoGammaInfoDto PhoGammaInfo { get; set; }
        public XRFInfoDto XRFInfo { get; set; }
    }

    public class GammaInfoDto
    {
        public List<GammaCalibrationDto> Calibrations { get; set; }
    }

    public class GammaCalibrationDto
    {
        public string Khoang { get; set; }
        public string HeSoChuanMay { get; set; }
    }

    public class PhoGammaInfoDto
    {
        public double K { get; set; }
        public double U { get; set; }
        public double Th { get; set; }
    }

    public class XRFInfoDto
    {
        public string Note { get; set; }
    }
}
