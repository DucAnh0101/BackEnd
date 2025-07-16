using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Models
{
    public class PhoGammaInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int MeasuringDeviceId { get; set; }

        public virtual MeasuringDevice MeasuringDevice { get; set; }

        [Required]
        public double K { get; set; }

        [Required]
        public double U { get; set; }

        [Required]
        public double Th { get; set; }
    }
}