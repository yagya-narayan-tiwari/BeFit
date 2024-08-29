using System.ComponentModel.DataAnnotations;

namespace BeFir.Models
{
    public class Admin
    {
        [Key]
        [Required(ErrorMessage = "Username required")]
        [StringLength(20, ErrorMessage = "username is too long")]
        public string Username { set; get; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password must be between 8 and 20 characters")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,20}$", ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one digit, and one special character")]
        public string Password { set; get; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { set; get; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        [RegularExpression(@"^\+?\d{10,15}$", ErrorMessage = "Phone number must be between 10 and 15 digits and can start with a +")]
        public string PhoneNumber { set; get; }
    }
}
