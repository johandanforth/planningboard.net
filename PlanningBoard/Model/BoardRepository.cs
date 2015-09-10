using System.Collections.Generic;
using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;

namespace PlanningBoard.Model
{
    public class BoardRepository : BaseRepository, IBoardRepository
    {
        public List<Board> List()
        {
            using (var cnn = GetDbConnection())
            {
                return cnn.Query<Board>("select * from boards").ToList();
            }
        }

        public int Add(Board board)
        {
            using (var cnn = GetDbConnection())
            {
                return (int) cnn.Insert(board);
            }
        }

        public Board Get(int id)
        {
            using (var cnn = GetDbConnection())
            {
                return cnn.Get<Board>(id);
            }
        }

        public void Update(Board board)
        {
            using (var cnn = GetDbConnection())
            {
                SqlMapperExtensions.Update(cnn, board);
            }
        }
    }
}