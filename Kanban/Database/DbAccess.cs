using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaskManager.WorkControl;
using TaskManager.UserControl;
using TaskManager.GroupControl;
using TaskManager.Database.Util;
using System.Numerics;

namespace TaskManager.Database  
{
    /// <summary>
    /// Class <c>DbAccess</c> is responsible for direct comunication with database
    /// </summary>
    public class DbAccess: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Work> Works { get; set; }


        public string DbPath { get; } = @"server=(localdb)\MSSQLLocalDB; Initial Catalog=Kanban; Integrated Security=true";
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(DbPath);

        /// <summary>
        /// Method <c>RefreshDB</c> deletes and rebuilds the database.
        /// Should be used only on Startup!
        /// </summary>
        public void RefreshDB()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(e => e.GroupsMember)
                .WithMany(e => e.Members);


            modelBuilder.Entity<User>()
                .HasMany(e => e.AssignedWorks)
                .WithMany(e => e.AssignedUsers);

            modelBuilder.Entity<User>()
                .HasMany(e => e.OwnedWorks)
                .WithOne(e => e.Creator)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.AssignedWorks)
                .WithMany(e => e.AssignedGroups);

            modelBuilder.Entity<User>()
                .HasMany(e => e.OwnedGroups)
                .WithOne(e => e.Creator)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>().HasData(
                //new User
                //{
                //    Id = -1,
                //    Name = "David",
                //    Email = "m@x",
                //    PasswordHash = User.HashPassword("pass"),
                //    AdminRights = false
                //},
                //new User
                //{
                //    Id = -2,    
                //    Name = "Rikej",
                //    Email = "no",
                //    PasswordHash = User.HashPassword("12"),
                //    AdminRights = false
                //},
                new User
                {
                    Id = 1,
                    Name = "Admin",
                    Email = "",
                    PasswordHash = User.HashPassword(""),
                    AdminRights = true
                }
                );
        }
    }
}
