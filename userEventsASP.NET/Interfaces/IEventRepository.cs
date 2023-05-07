using Microsoft.AspNetCore.Mvc;
using userEventsASP.NET.Models;
using userEventsASP.NET.Pagination;

namespace userEventsASP.NET.Interfaces
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
