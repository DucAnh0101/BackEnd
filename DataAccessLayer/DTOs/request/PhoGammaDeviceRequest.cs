using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs.request
{
    public class PhoGammaDeviceRequest
    {
        public string SerialNumber { get; set; }
        public double? K { get; set; }
        public double? U { get; set; }
        public double? Th { get; set; }
    }
}
