using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs.request
{
    public class GammaReq
    {
        [Required]
      
        public Double Khoang { get; set; }

        [Required]

        public Double HeSoChuanMay { get; set; }

        [Required]
        public int MeasuringDeviceId { get; set; }
    }
}

