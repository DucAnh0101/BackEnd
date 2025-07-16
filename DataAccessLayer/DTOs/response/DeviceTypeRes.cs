using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs.response
{
    public class DeviceTypeRes
    {
        public int Id { get; set; }

        public string TypeName { get; set; } = null!;
    }
}
