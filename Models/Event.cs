using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class Event : BaseEntity
    {
        [Required] [MaxLength(250)] public string Name { get; set; }
    }
}