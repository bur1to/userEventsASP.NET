using System.ComponentModel.DataAnnotations;

namespace userEventsASP.NET.Models
{
    public class User
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "First name is required. Please fill this field")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required. Please fill this field")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required. Please fill this field")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Password is required. Please fill this field")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please confirm your password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public string? Token { get; set; }
    }
}
