using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs.response
{
    public class DeviceRes
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string Type { get; set; }

        // Dữ liệu dành riêng cho Gamma
        public List<GammaCalibrationRes>? Calibrations { get; set; }

        // Dữ liệu dành riêng cho Phổ Gamma
        public double? K { get; set; }
        public double? U { get; set; }
        public double? Th { get; set; }

        // Dữ liệu dành riêng cho XRF
        public string? Note { get; set; }
    }

    public class GammaCalibrationRes
    {
        public string Khoang { get; set; }
        public string HeSoChuanMay { get; set; }
    }
}
