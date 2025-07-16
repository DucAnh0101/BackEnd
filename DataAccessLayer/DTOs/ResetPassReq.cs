using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.DTOs
{
    public class ResetPassReq
    {
        [Required(ErrorMessage = "Username is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Citizen ID is required")]
        [StringLength(12, MinimumLength = 9, ErrorMessage = "Citizen ID must be between 9 and 12 characters")]
        [RegularExpression(@"^[0-9]{9}$|^[0-9]{12}$", ErrorMessage = "Citizen ID must be 9 digits (old format) or 12 digits (new format)")]
        public string CitizenId { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date)]
        public DateOnly DOB { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must be exactly 10 digits")]
        [RegularExpression(@"^(03|05|07|08|09)[0-9]{8}$", ErrorMessage = "Phone number must start with 03, 05, 07, 08, or 09 and be exactly 10 digits")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(50, ErrorMessage = "Email cannot exceed 50 characters")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
    }
}