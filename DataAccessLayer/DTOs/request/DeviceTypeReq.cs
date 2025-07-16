using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs.request
{
    public class DeviceTypeReq
    {
        [Required]
        [MaxLength(100)]
        public string TypeName { get; set; } = null!;
    }
}
