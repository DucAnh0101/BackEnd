using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs.response
{
    public class GammaRes
    {
        public int Id { get; set; }

        public Double Khoang { get; set; }

        public  Double HeSoChuanMay { get; set; }

        public int MeasuringDeviceId { get; set; }
    }
}
