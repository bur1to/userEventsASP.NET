using userEventsAndBlogs.Models;
using userEventsAndBlogs.Pagination;

namespace userEventsAndBlogs.Interfaces
{
    public interface IBlogRepository
    {
        public Tuple<List<Blog>, int> GetBlogs(PaginationParams param);
        public Tuple<List<Blog>, int> GetBlogs(Guid userId, PaginationParams param);
        public Blog GetBlog(Guid id);
        public bool CreateBlog(Blog blog);
        public bool UpdateBlog(Blog blog);
        public bool DeleteBlog(Blog blog);
        public bool Save();
    }
}
