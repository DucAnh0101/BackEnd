using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs.request
{
    public class DeviceReq
    {
        public string SerialNumber { get; set; }

        /// <summary>
        /// Loại thiết bị: "gamma", "phogamma", "xrf"
        /// </summary>
        public string Type { get; set; }

        // Dữ liệu dành riêng cho Gamma
        public List<GammaCalibrationReq>? Calibrations { get; set; }

        // Dữ liệu dành riêng cho Phổ Gamma
        public double? K { get; set; }
        public double? U { get; set; }
        public double? Th { get; set; }

        // Dữ liệu dành riêng cho XRF
        public string? Note { get; set; }
    }

    public class GammaCalibrationReq
    {
        public string Khoang { get; set; }
        public string HeSoChuanMay { get; set; }
    }
}
