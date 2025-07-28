using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs.request
{
    public class XrfDeviceRequest
    {
        public string SerialNumber { get; set; }
        public string Note { get; set; }
    }
}
