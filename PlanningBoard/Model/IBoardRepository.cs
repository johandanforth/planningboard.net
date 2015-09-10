using System.Collections.Generic;

namespace PlanningBoard.Model
{
    public interface IBoardRepository
    {
        List<Board> List();
        int Add(Board board);
        Board Get(int id);
        void Update(Board board);
    }
}