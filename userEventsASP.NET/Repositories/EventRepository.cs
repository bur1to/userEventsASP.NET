using userEventsAndBlogs.Models;
using userEventsAndBlogs.Data;
using userEventsAndBlogs.Interfaces;
using userEventsAndBlogs.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace userEventsAndBlogs.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext _context;
        public EventRepository(AppDbContext context)
        {
            _context = context;
        }

        public Tuple<List<Event>, int> GetEvents([FromQuery] PaginationParams param)
        {
            var events = _context.Events
                .Skip(param.Page * 5)
                .Take(5)
                .ToList();
            var count = _context.Events.Count();
                   
            return Tuple.Create(events, count);
        }

        public Tuple<List<Event>, int> GetEvents(Guid userId, [FromQuery] PaginationParams param)
        {
            var events = _context.Events
                .Where(x => x.UserId == userId)
                .Skip(param.Page * 5)
                .Take(5)
                .ToList();
            var count =_context.Events.Where(x => x.UserId == userId).Count();
            
            return Tuple.Create(events, count);
        }

        public Event GetEvent(Guid id)
        {
            return _context.Events.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool CreateEvent(Event evnt)
        {
            _context.Events.Add(evnt);
            return Save();
        }

        public bool UpdateEvent(Event evnt)
        {
            _context.Events.Update(evnt);
            return Save();
        }

        public bool DeleteEvent(Event evnt)
        {
            _context.Events.Remove(evnt);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
