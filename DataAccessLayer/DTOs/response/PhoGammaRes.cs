using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs.response
{
    public class PhoGammaRes
    {
        public int Id { get; set; }

        public int MeasuringDeviceId { get; set; }

        public double K { get; set; }

        public double U { get; set; }

        public double Th { get; set; }
    }
}
