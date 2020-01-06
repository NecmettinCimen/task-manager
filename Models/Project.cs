using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class Project : BaseEntity
    {
        [Required] [MaxLength(250)] public string Title { get; set; }

        [MaxLength(250)] public string Url { get; set; }

        [MaxLength] public string Explanation { get; set; }

        public User Manager { get; set; }
        public int ManagerId { get; set; } = 1;
        public Event Event { get; set; }
        public int EventId { get; set; } = 1;
    }
}