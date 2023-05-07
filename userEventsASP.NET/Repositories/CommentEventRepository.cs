using userEventsASP.NET.Interfaces;
using userEventsASP.NET.Data;
using userEventsASP.NET.Models;

namespace userEventsASP.NET.Repositories
{
    public class CommentEventRepository : ICommentEventRepository
    {
        private readonly AppDbContext _context;
        public CommentEventRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool CreateComment(EventComment comment)
        {
            _context.EventComments.Add(comment);
            return Save();
        }

        public bool DeleteComment(EventComment comment)
        {
            _context.EventComments.Remove(comment);
            return Save();
        }

        public EventComment GetComment(Guid id)
        {
            return _context.EventComments.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<EventComment> GetComments(Guid eventId)
        {
            return _context.EventComments.Where(x => x.EventId == eventId).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateComment(EventComment comment)
        {
            _context.EventComments.Update(comment);
            return Save();
        }
    }
}
