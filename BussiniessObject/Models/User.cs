using System.ComponentModel.DataAnnotations;

namespace BussiniessObject.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string CitizenId { get; set; }
        [Required]
        public DateOnly DOB { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
