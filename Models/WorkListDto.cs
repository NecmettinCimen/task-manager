namespace TaskManager.Models
{
    public class WorkListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Project { get; set; }
        public string Event { get; set; }
        public int WorkProgres { get; set; }
    }
}