namespace TaskManager.Models
{
    public class WorkHistory : BaseEntity
    {
        public short PrevStatus { get; set; }
        public Work Work { get; set; }
        public int WorkId { get; set; }
        public User Manager { get; set; }
        public int ManagerId { get; set; } = 1;
    }
}