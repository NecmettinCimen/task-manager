using System.Collections.Generic;

namespace TaskManager.Models
{
    public class HomeIndexViewModel
    {
        public List<ProjectListDto> ProjectList { get; set; }
        public List<WorkListDto> WorkList { get; set; }
    }
}