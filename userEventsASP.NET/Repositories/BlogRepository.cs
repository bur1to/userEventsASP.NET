using userEventsASP.NET.Models;
using userEventsASP.NET.Data;
using userEventsASP.NET.Interfaces;
using Microsoft.AspNetCore.Mvc;
using userEventsASP.NET.Pagination;

namespace userEventsASP.NET.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly AppDbContext _context;
        public BlogRepository(AppDbContext context)
        {
            _context = context;
        }

        public Tuple<List<Blog>, int> GetBlogs([FromQuery] PaginationParams param)
        {
            var blogs = _context.Blogs
                .Skip(param.Page * 5)
                .Take(5)
                .ToList();
            var count = _context.Blogs.Count();

            return Tuple.Create(blogs, count);
        }

        public Tuple<List<Blog>, int> GetBlogs(Guid userId, [FromQuery] PaginationParams param)
        {
            var blogs = _context.Blogs
                .Where(x => x.UserId == userId)
                .Skip(param.Page * 5)
                .Take(5)
                .ToList();
            var count = _context.Blogs.Where(x => x.UserId == userId).Count();
            return Tuple.Create(blogs, count);
        }

        public Blog GetBlog(Guid id)
        {
            return _context.Blogs.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool CreateBlog(Blog blog)
        {
            _context.Blogs.Add(blog);
            return Save();
        }

        public bool UpdateBlog(Blog blog)
        {
            _context.Blogs.Update(blog);
            return Save();
        }

        public bool DeleteBlog(Blog blog)
        {
            _context.Blogs.Remove(blog);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
