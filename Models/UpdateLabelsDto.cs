using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    public class UpdateLabelsDto
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public int WorkId { get; set; }
    }
}
