﻿using BE.Domain.Entities.Roles;
using BE.Domain.Entities.Rooms;
﻿using BE.Domain.Entities.Buildings;
using BE.Domain.Entities.Users;
using BE.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;

namespace BE.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            builder.ConfigureConventions();
            builder.IsDeletedFilter();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        
        public DbSet<User> Users => this.Set<User>();
        public DbSet<Role> Roles => this.Set<Role>();
        public DbSet<UserRoles> UserRoles => this.Set<UserRoles>();
        public DbSet<Room> Rooms => this.Set<Room>();
        public DbSet<Building> Buildings => this.Set<Building>();
    }
}
