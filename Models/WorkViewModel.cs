using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    public class WorkViewModel :Work
    {
        public List<Work> ChildWorkList { get; set; }
        public string EventName { get; set; }
    }
}
