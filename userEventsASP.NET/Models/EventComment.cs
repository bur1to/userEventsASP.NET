namespace userEventsASP.NET.Models
{
    public class EventComment
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid EventId { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
    }
}
