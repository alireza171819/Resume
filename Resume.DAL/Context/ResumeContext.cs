using Microsoft.EntityFrameworkCore;
using Resume.DAL.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Context;

public class ResumeContext : DbContext
{
    public ResumeContext(DbContextOptions<ResumeContext> options) : base(options)
    {
        
    }

    public DbSet<User> Users { get; set; }

    #region On Model Creating

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Seed Data 

        modelBuilder.Entity<User>().HasData(new User() 
        {
            Id = 1,
            FirstName = "Alireza",
            LastName = "Khalili",
            Username = "Alireza Khalili",
            Email = "alirezakhalili1380.12.11@gmail.com",
            Password = "82-7C-CB-0E-EA-8A-70-6C-4C-34-A1-68-91-F8-4E-7B",
            Gender = "famel",
            Phone = "09919276452",
            DateOfBirth = DateTime.UtcNow,
            Active = true,
            Deleted = false,
            LastLoginDateUtc = DateTime.UtcNow,
            CreatedOnUtc = DateTime.UtcNow,

        });

        #endregion
        base.OnModelCreating(modelBuilder);
    }
    #endregion
}
