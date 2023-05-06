using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace userEventsAndBlogs.Models
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
