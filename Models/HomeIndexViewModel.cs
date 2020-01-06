using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    public class HomeIndexViewModel
    {
        public List<ProjectListDto> ProjectList { get; set; }
        public List<WorkListDto> WorkList { get; set; }
    }
    public class ProjectListDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public int WorkProgres { get; set; }
    }
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
