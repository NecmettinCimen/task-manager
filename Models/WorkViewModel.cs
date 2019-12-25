using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    public class WorkViewModel :Work
    {
        public List<WorkDto> ChildWorkList { get; set; }
        public string EventName { get; set; }
        public List<Event> EventList { get; internal set; }
        public List<Label> LabelList { get; internal set; }
        public string ProjectName { get; internal set; }
        public string ProjectUrl { get; internal set; }
        public int ProjectManagerId { get; internal set; }
    }
}
