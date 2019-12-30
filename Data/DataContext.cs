
using CustomServer.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomServer.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        //public DbSet<MyObject> MyObjects { get; set;}
        public DbSet<User> Users { get; set;}
    }
}