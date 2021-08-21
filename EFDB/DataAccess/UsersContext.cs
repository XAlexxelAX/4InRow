using EFDB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDB.DataAccess
{
    public class UsersContext:DbContext
    {
        /*public UsersContext(DbContextOptions<UsersContext> options): base(options)
        {
        }*/
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=connectFour;Trusted_Connection=True");
        }

        public DbSet<Game> games { get; set; }
        public DbSet<UserModel> users { get; set; }
    }
}
