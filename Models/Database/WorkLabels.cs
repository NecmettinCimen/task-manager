namespace TaskManager.Models
{
    public class WorkLabels : BaseEntity
    {
        public Work Work { get; set; }
        public int WorkId { get; set; }
        public Label Label { get; set; }
        public int LabelId { get; set; }
    }
}