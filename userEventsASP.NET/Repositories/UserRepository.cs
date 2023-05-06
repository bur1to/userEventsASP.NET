using userEventsAndBlogs.Models;
using userEventsAndBlogs.Data;
using userEventsAndBlogs.Interfaces;
using Microsoft.AspNetCore.Mvc;
using userEventsAndBlogs.Pagination;

namespace userEventsAndBlogs.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public Tuple<List<User>, int> GetUsers([FromQuery] PaginationParams param)
        {
            var users = _context.Users
                .Skip(param.Page * 5)
                .Take(5)
                .ToList();
            var count = _context.Users.Count();
            var result = Tuple.Create(users, count);

            return result;
        }

        public User GetUser(Guid id)
        {
            return _context.Users.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool CreateUser(User user)
        {
            _context.Users.Add(user);
            return Save();
        }

        public bool UpdateUser(User user)
        {
            _context.Users.Update(user);
            return Save();
        }

        public bool DeleteUser(User user)
        {
            _context.Users.Remove(user);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
        public bool UserExists(Guid id)
        {
            return _context.Users.Any(x => x.Id == id);
        }

        public bool UserExists(string email)
        {
            return _context.Users.Any(x => x.Email == email);
        }
    }
}
