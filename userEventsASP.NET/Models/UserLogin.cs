using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace userEventsASP.NET.Models
{
    public class UserLogin
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
