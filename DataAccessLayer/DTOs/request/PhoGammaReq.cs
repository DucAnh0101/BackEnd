using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs.request
{
    public class PhoGammaReq
    {
        [Required]
        public int MeasuringDeviceId { get; set; }

        [Required]
        public double K { get; set; }

        [Required]
        public double U { get; set; }

        [Required]
        public double Th { get; set; }
    }
}
