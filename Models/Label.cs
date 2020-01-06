using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class Label : BaseEntity
    {
        [Required] [MaxLength(250)] public string Name { get; set; }
    }
}