using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskManager.Models
{
    public class MainContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<WorkHistory> WorkHistorys { get; set; }
        public DbSet<Event> Events { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User
            { Id = 1, NameSurname = "Admin", Email = "admin", Password = "1" });
            modelBuilder.Entity<Event>().HasData(new Event
            { Id = 1, Name = "Oluþturuldu."});
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Data Source=localhost\\sekiz;Initial Catalog=dbtaskmanager;User ID=sa;Password=Nebula21;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }

    public class BaseEntity
    {
        public int Id { get; set; }
        public short Status { get; set; } = 1;
        public DateTime CreateDate { get; set; } = new DateTime(2020, 1, 1);
        [ForeignKey("Users")]
        public int CreatorId { get; set; } = 1;
    }

    public class User : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string NameSurname { get; set; }
        [Required]
        [MaxLength(150)]
        public string Email { get; set; }
        [Required]
        [MaxLength(150)]
        public string Password { get; set; }
    }
    public class Event : BaseEntity
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
    }

    public class Project : BaseEntity
    {
        [Required]
        [MaxLength(250)]
        public string Title { get; set; }
        [MaxLength(1000)]
        public string Explanation { get; set; }
        [ForeignKey("Users")]
        public int ManagerId { get; set; } = 1;
        [ForeignKey("Events")]
        public int EventId { get; set; } = 1;
    }
    public class Work : BaseEntity
    {
        [Required]
        [MaxLength(250)]
        public string Title { get; set; }
        [MaxLength(1000)]
        public string Explanation { get; set; }
        [ForeignKey("Projects")]
        public int ProjectId { get; set; }
        [ForeignKey("Users")]
        public int ManagerId { get; set; } = 1;
        [ForeignKey("Events")]
        public int EventId { get; set; } = 1;
    }

    public class WorkHistory : BaseEntity
    {
        public short PrevStatus { get; set; }
        [ForeignKey("Works")]
        public int WorkId { get; set; }
        [ForeignKey("Users")]
        public int ManagerId { get; set; } = 1;
    }
}