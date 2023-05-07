using AutoMapper;
using userEventsASP.NET.Dto;
using userEventsASP.NET.Models;

namespace userEventsASP.NET.Helping
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
