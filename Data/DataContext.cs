
using CustomServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CustomServer.Data
{
    public class DataContext :IdentityDbContext<User,Role,long,IdentityUserClaim<long>,UserRole,IdentityUserLogin<long>,IdentityRoleClaim<long>,IdentityUserToken<long>>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        //public DbSet<MyObject> MyObjects { get; set;}
        //public DbSet<User> Users { get; set;}
        public DbSet<Profile> Profiles { get; set;}
        public DbSet<Photo> Photos { get; set;}

        protected override void OnModelCreating(ModelBuilder builder){
            base.OnModelCreating(builder);

            builder.Entity<User>().Ignore(c => c.PhoneNumber)
                                  .Ignore(c => c.PhoneNumberConfirmed);
                                
            builder.Entity<User>().ToTable("AspNetUsers");

            builder.Entity<UserRole>(userRole =>{
                userRole.HasKey(ur => new {ur.UserId, ur.RoleId});
                userRole.HasOne(ur => ur.Role)
                        .WithMany(r => r.UserRoles)
                        .HasForeignKey(ur => ur.RoleId)
                        .IsRequired();

                userRole.HasOne(ur => ur.User)
                        .WithMany(r => r.UserRoles)
                        .HasForeignKey(ur => ur.UserId)
                        .IsRequired();
            });
        }
    }
}