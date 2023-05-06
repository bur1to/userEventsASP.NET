using System.ComponentModel.DataAnnotations;

namespace userEventsAndBlogs.Models
{
    public class Event
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        [Required(ErrorMessage = "Title is required. Please fill this field")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is required. Please fill this field")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Star date is required. Please fill this field")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "End date is required. Please fill this field")]
        public DateTime EndDate { get; set; }
    }
}
