using userEventsAndBlogs.Models;
using userEventsAndBlogs.Data;
using userEventsAndBlogs.Interfaces;

namespace userEventsAndBlogs.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _context;
        public CommentRepository(AppDbContext context)
        {
            _context = context;
        }   

        public List<Comment> GetComments(Guid blogId)
        {
            return _context.Comments.Where(x => x.BlogId == blogId).ToList();
        }

        public bool CreateComment(Comment comment)
        {
            _context.Comments.Add(comment);
            return Save();
        }

        public bool UpdateComment(Comment comment)
        {
            _context.Comments.Update(comment);
            return Save();
        }

        public bool DeleteComment(Comment comment)
        {
            _context.Comments.Remove(comment);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public Comment GetComment(Guid commentId)
        {
            return _context.Comments.Where(x => x.Id == commentId).FirstOrDefault();
        }
    }
}
