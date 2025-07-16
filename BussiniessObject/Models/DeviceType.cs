using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Models
{
    public class DeviceType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string TypeName { get; set; }

        public virtual ICollection<MeasuringDevice> MeasuringDevices { get; set; } = new List<MeasuringDevice>();
    }
}