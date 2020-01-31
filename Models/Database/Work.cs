using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class Work : BaseEntity
    {
        [Required] [MaxLength(250)] public string Title { get; set; }

        [MaxLength(250)] public string Url { get; set; }

        [MaxLength] public string Explanation { get; set; }

        public Project Project { get; set; }
        public int ProjectId { get; set; }
        public User Manager { get; set; }
        public int ManagerId { get; set; } = 1;
        public Event Event { get; set; }
        public int EventId { get; set; } = 1;
        public Work ParentWork { get; set; }
        public int? ParentWorkId { get; set; }
    }
}