using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaskManager.TaskControl;
using TaskManager.UserControl;
using TaskManager.GroupControl;
using TaskManager.Database.Util;
using System.Numerics;

namespace TaskManager.Database  
{
    public class DbAccess: DbContext
    {
        public DbSet<User> Users { get; set; }
        //public DbSet<Group> Groups { get; set; }
        public DbSet<Work> Works { get; set; }

        //public GroupDatabase GroupUtils { get; }

        public DbAccess() : base()
        {

            //GroupUtils = new(this);
        }

        public string DbPath { get; } = @"server=(localdb)\MSSQLLocalDB; Initial Catalog=Kanban; Integrated Security=true";
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(DbPath);


        public void RefreshDB()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = -1,
                    Name = "David",
                    Email = "m@x",
                    PasswordHash = User.HashPassword("pass")
                },
                new User
                {
                    Id = -2,    
                    Name = "Rikej",
                    Email = "no",
                    PasswordHash = User.HashPassword("12")
                }
                );
        }
    }

}
