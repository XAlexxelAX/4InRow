using EFDB.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDB.DataAccess
{
    public class UsersContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"AttachDbFilename=C:\fourinrow\fourinrow_avi_evyatar.mdf;Server=(localdb)\mssqllocaldb;Database=fourinarow;Trusted_Connection=True");//Data Source=c:\fourinrow;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();
        }

        public DbSet<Game> games { get; set; }
        public DbSet<UserModel> users { get; set; }
    }
}
