using System.Collections.Generic;
using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;

namespace PlanningBoard.Model
{
    public class ColumnRepository : BaseRepository, IColumnRepository
    {
        public List<Column> List(int boardId)
        {
            using (var cnn = GetDbConnection())
            {
                return cnn.Query<Column>("select * from columns where boardId = @boardId", new {boardId }).ToList();
            }
        }

        public int Add(Column column)
        {
            using (var cnn = GetDbConnection())
            {
                return (int)cnn.Insert(column);
            }
        }
    }
}