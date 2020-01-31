using System;

namespace TaskManager.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public short Status { get; set; } = 1;
        public bool Public { get; set; } = true;
        public DateTime CreateDate { get; set; } = new DateTime(2020, 1, 1);
        public User Creator { get; set; }
        public int CreatorId { get; set; } = 1;
    }
}