using System.ComponentModel;

namespace userEventsAndBlogs.Pagination
{
    public class PaginationParams
    {
        [DefaultValue(0)]
        public int Page { get; set; }
        /*public int? Limit { get; set; }*/
    }
}
