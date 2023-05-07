using userEventsASP.NET.Models;

namespace userEventsASP.NET.Interfaces
{
    public interface ICommentRepository
    {
        public List<Comment> GetComments(Guid blogId);
        public Comment GetComment(Guid commentId);
        public bool CreateComment(Comment comment);
        public bool UpdateComment(Comment comment);
        public bool DeleteComment(Comment comment);
        public bool Save();
    }
}
