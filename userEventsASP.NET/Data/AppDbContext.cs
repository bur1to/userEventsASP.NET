﻿using Microsoft.EntityFrameworkCore;
using userEventsASP.NET.Models;

namespace userEventsASP.NET.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<EventComment> EventComments { get; set; }
    }
}
