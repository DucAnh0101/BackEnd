using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs.response
{
    public class XrfRes
    {
        public int Id { get; set; }

        public int MeasuringDeviceId { get; set; }

        public string Note { get; set; } = null!;
    }
}
