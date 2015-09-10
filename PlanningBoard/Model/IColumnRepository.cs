using System.Collections.Generic;

namespace PlanningBoard.Model
{
    public interface IColumnRepository
    {
        List<Column> List(int boardId);
        int Add(Column column);
    }
}