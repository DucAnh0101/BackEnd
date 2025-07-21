using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int RoleId { get; set; } = 0;

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        [Required]
        [StringLength(20)]
        public string CitizenId { get; set; }

        [Required]
        public DateOnly DOB { get; set; }

        [Required]
        [StringLength(10)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(1000)]
        public string AvtUrl { get; set; }

        [Required]
        public bool IsDelete { get; set; } = false;

        [Required]
        public bool IsMale { get; set; } = false;

        public virtual ICollection<SurveyPoint> SurveyPoints { get; set; } = new List<SurveyPoint>();
        public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();
    }
}