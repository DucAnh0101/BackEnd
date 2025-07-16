using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Models
{
    public class XRFInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int MeasuringDeviceId { get; set; }

        public virtual MeasuringDevice MeasuringDevice { get; set; }

        [MaxLength(1000)]
        public string Note { get; set; }
    }
}