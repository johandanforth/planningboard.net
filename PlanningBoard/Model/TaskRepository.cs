using System.Collections.Generic;
using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;

namespace PlanningBoard.Model
{
    public class TaskRepository : BaseRepository, ITaskRepository
    {

        public int Add(Task task)
        {
            using (var cnn = GetDbConnection())
            {
                return (int)cnn.Insert(task);
            }
        }

        public void Delete(Task task)
        {
            using (var cnn = GetDbConnection())
            {
                cnn.Delete(task);
            }
        }

        public void Update(Task task)
        {
            using (var cnn = GetDbConnection())
            {
                SqlMapperExtensions.Update(cnn, task);
            }
        }

        public Task Get(int id)
        {
            using (var cnn = GetDbConnection())
            {
                return cnn.Get<Task>(id);
            }
        }

        public List<Task> List(int boardId)
        {
            using (var cnn = GetDbConnection())
            {
                return cnn.Query<Task>("select t.* from tasks t inner join columns c on c.id = t.columnid where c.boardId == @boardId",
                    new { boardId }).ToList();
            }
        }

        public List<Task> List()
        {
            using (var cnn = GetDbConnection())
            {
                return cnn.Query<Task>("select * from tasks").ToList();
            }
        }
    }
}