using Microsoft.AspNetCore.Mvc;
using userEventsAndBlogs.Models;
using userEventsAndBlogs.Pagination;

namespace userEventsAndBlogs.Interfaces
{
    public interface IUserRepository
    {
        public Tuple<List<User>, int> GetUsers([FromQuery] PaginationParams param);
        public User GetUser(Guid id);
        public bool CreateUser(User user);
        public bool UpdateUser(User user);
        public bool DeleteUser(User user);
        public bool Save();
        public bool UserExists(Guid id);
        public bool UserExists(string email);

    }
}
