namespace userEventsASP.NET.Dto
{
    public class CommentDto
    {
        public Guid UserId { get; set; }
        public Guid BlogId { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
