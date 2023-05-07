using userEventsASP.NET.Models;

namespace userEventsASP.NET.Interfaces
{
    public interface ICommentEventRepository
    {
        public List<EventComment> GetComments(Guid eventId);
        public bool CreateComment(EventComment comment);
        public bool UpdateComment(EventComment comment);
        public bool DeleteComment(EventComment comment);
        public EventComment GetComment(Guid id);
        public bool Save();
    }
}
