using System.ComponentModel;

namespace userEventsASP.NET.Pagination
{
    public class PaginationParams
    {
        [DefaultValue(0)]
        public int Page { get; set; }
        /*public int? Limit { get; set; }*/
    }
}
