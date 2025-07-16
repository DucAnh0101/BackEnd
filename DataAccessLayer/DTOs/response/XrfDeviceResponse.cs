using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs.response
{
   public class XrfDeviceResponse
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string Note { get; set; }
    }
}
