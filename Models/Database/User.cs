using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class User : BaseEntity
    {
        [Required] [MaxLength(100)] public string NameSurname { get; set; }

        [Required] [MaxLength(150)] public string Email { get; set; }

        [Required] [MaxLength(150)] public string Password { get; set; }
    }
}