using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class MainContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<WorkHistory> WorkHistorys { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<WorkLabels> WorkLabels { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User
            { Id = 1, NameSurname = "Admin", Email = "admin", Password = "1", Public=true });
            modelBuilder.Entity<Event>().HasData(new Event { Id = 1, Name = "Bekliyor", Public = true });
            modelBuilder.Entity<Event>().HasData(new Event { Id = 2, Name = "İşlemde", Public = true });
            modelBuilder.Entity<Event>().HasData(new Event { Id = 3, Name = "Tamamlandı", Public = true });
            modelBuilder.Entity<Event>().HasData(new Event { Id = 4, Name = "Red Edildi", Public = true });
            modelBuilder.Entity<Label>().HasData(new Label { Id = 1, Name = "Web", Public = true });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.EnableSensitiveDataLogging(false);
                optionsBuilder.UseSqlServer("Data Source=localhost\\sekiz;Initial Catalog=dbtaskmanager;User ID=sa;Password=Nebula21");
            }
        }
    }

    public class BaseEntity
    {
        public int Id { get; set; }
        public short Status { get; set; } = 1;
        public bool Public { get; set; } = true;
        public DateTime CreateDate { get; set; } = new DateTime(2020, 1, 1);
        public User Creator { get; set; }
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
        [MaxLength(250)]
        public string Url { get; set; }
        [MaxLength]
        public string Explanation { get; set; }
        public User Manager { get; set; }
        public int ManagerId { get; set; } = 1;
        public Event Event { get; set; }
        public int EventId { get; set; } = 1;
    }

    public class Work : BaseEntity
    {
        [Required]
        [MaxLength(250)]
        public string Title { get; set; }
        [MaxLength(250)]
        public string Url { get; set; }
        [MaxLength]
        public string Explanation { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }
        public User Manager { get; set; }
        public int ManagerId { get; set; } = 1;
        public Event Event { get; set; }
        public int EventId { get; set; } = 1;
        public Work ParentWork { get; set; }
        public int? ParentWorkId { get; set; }
    }

    public class WorkHistory : BaseEntity
    {
        public short PrevStatus { get; set; }
        public Work Work { get; set; }
        public int WorkId { get; set; }
        public User Manager { get; set; }
        public int ManagerId { get; set; } = 1;
    }

    public class Label : BaseEntity
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
    }

    public class WorkLabels : BaseEntity
    {
        public Work Work { get; set; }
        public int WorkId { get; set; }
        public Label Label { get; set; }
        public int LabelId { get; set; }
    }
}