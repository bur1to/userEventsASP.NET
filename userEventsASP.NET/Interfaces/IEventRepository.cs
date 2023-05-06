using Microsoft.AspNetCore.Mvc;
using userEventsAndBlogs.Models;
using userEventsAndBlogs.Pagination;

namespace userEventsAndBlogs.Interfaces
{
    public interface IEventRepository
    {
        public Tuple<List<Event>, int> GetEvents([FromQuery] PaginationParams param);
        public Tuple<List<Event>, int> GetEvents(Guid userId, [FromQuery] PaginationParams param);
        public Event GetEvent(Guid id);
        public bool CreateEvent(Event evnt);
        public bool UpdateEvent(Event evnt);
        public bool DeleteEvent(Event evnt);
        public bool Save();
    }
}
