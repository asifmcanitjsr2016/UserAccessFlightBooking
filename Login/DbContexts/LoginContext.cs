using Login.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Login.DBContexts
{
    public class LoginContext : DbContext
    {
        public LoginContext(DbContextOptions<LoginContext> options) : base(options)
        {
        }        
        public DbSet<UserLoginDetails> UserLoginDetails { get; set; }                

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserLoginDetails>().HasData(
                new UserLoginDetails
                {
                    UserType = "Admin",
                    UserID = "asif123@gmail.com",
                    Name = "Asif Hussain",
                    Age = 30,
                    Gender = "Male",
                    Password = "Asif@123Hussain",
                    AccountCreated = DateTime.Now
                }
            );
        }
    }
    
}
