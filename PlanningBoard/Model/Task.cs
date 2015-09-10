namespace PlanningBoard.Model
{
    public class Task
    {
        public int Id { get; set; }
        public int ColumnId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
        public int Prio { get; set; }
        public int ColorId { get; set; }

        public Task()
        {
            Owner = "";
            Prio = 100;
            ColorId = 1;
            ColumnId = 1;
        }
    }
}