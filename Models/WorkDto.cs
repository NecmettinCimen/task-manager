using System.Collections.Generic;

namespace TaskManager.Models
{
    public class WorkDto : Work
    {
        public string EventName { get; set; }
        public string FirstLabelName { get; set; }
        public List<int> Labels { get; set; }
        public int WorkProgres { get; set; }
    }
}