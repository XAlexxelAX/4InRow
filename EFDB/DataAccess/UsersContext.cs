using EFDB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDB.DataAccess
{
    public class UsersContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=c:\fourinarow;Server=(localdb)\mssqllocaldb;Database=fourinarow;Trusted_Connection=True");//Data Source=c:\fourinrow;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>()
                .HasKey(u => new { u.Id, u.Username });
            modelBuilder.Entity<UserModel>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();
        }

        public DbSet<Game> games { get; set; }
        public DbSet<UserModel> users { get; set; }
    }
}
