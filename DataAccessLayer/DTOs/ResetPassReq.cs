using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.DTOs
{
    public class ResetPassReq
    {
        [Required]
        public string UserName { get; set; }
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
