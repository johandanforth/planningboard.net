using System.Collections.Generic;
using PlanningBoard.Model;

namespace PlanningBoard.ViewModels
{
    public class BoardViewModel
    {
        public List<Column> Columns { get; set; }
        public List<Color> Colors { get; set; }
        public List<Task> Tasks { get; set; }
        public Board Board { get; set; }
    }
}