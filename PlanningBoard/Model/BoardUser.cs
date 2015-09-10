namespace PlanningBoard.Model
{
    public class BoardUser
    {
        public int BoardId { get; set; }
        public int UserId { get; set; }
        public bool IsAdmin { get; set; }
    }
}