using AutoMapper;
using userEventsAndBlogs.Dto;
using userEventsAndBlogs.Models;

namespace userEventsAndBlogs.Helping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<Blog, BlogDto>();
            CreateMap<BlogDto, Blog>();
            CreateMap<Event, EventDto>();
            CreateMap<EventDto, Event>();
            CreateMap<Comment, CommentDto>();
            CreateMap<CommentDto, Comment>();
        }
    }
}
