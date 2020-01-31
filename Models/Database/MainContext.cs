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
        public DbSet<Label> Labels { get; set; }
        public DbSet<WorkLabels> WorkLabels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User
                {Id = 1, NameSurname = "Admin", Email = "admin", Password = "1", Public = true});
            modelBuilder.Entity<Event>().HasData(new Event {Id = 1, Name = "Bekliyor", Public = true});
            modelBuilder.Entity<Event>().HasData(new Event {Id = 2, Name = "İşlemde", Public = true});
            modelBuilder.Entity<Event>().HasData(new Event {Id = 3, Name = "Tamamlandı", Public = true});
            modelBuilder.Entity<Event>().HasData(new Event {Id = 4, Name = "Red Edildi", Public = true});
            modelBuilder.Entity<Label>().HasData(new Label {Id = 1, Name = "Web", Public = true});
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.EnableSensitiveDataLogging(false);
                #if DEBUG
                optionsBuilder.UseSqlServer(
                    "Data Source=necmettincimen.com,51433;Initial Catalog=dbtaskmanager;User ID=sa;Password=Nebula21");
                #endif
#if !DEBUG
                optionsBuilder.UseSqlServer(
                    "Data Source=localhost\\sekiz;Initial Catalog=dbtaskmanager;User ID=sa;Password=Nebula21");
#endif

            }
        }
    }
}