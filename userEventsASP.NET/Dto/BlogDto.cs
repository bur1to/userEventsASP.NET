﻿namespace userEventsAndBlogs.Dto
{
    public class BlogDto
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Themes { get; set; }
        public string Content { get; set; }
        public DateTime PostDate { get; set; }
    }
}
