using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Models
{
    public class GammaCalibration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Khoang { get; set; }

        [Required]
        [MaxLength(100)]
        public string HeSoChuanMay { get; set; }

        [Required]
        public int GammaInfoId { get; set; }

        public virtual GammaInfo GammaInfo { get; set; }
    }
}