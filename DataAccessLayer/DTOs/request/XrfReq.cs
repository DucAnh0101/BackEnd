using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs.request
{
    public class XrfReq
    {
        [Required]
        public int MeasuringDeviceId { get; set; }

        [MaxLength(1000)]
        public string Note { get; set; }
    }
}
