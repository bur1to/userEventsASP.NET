using System.ComponentModel.DataAnnotations;

namespace userEventsAndBlogs.Models
{
    public class Blog
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Themes is required")]
        public string Themes { get; set; }
        [Required(ErrorMessage = "Content is required")]
        public string Content { get; set; }
        public DateTime PostDate { get; set; }
    }
}
