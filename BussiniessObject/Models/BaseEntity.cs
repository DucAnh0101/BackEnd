using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusiniessObject.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public string Status { get; set; } = "Active"; // "Active", "Deleted"
    }
}
