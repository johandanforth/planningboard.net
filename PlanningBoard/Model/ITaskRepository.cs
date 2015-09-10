using System.Collections.Generic;

namespace PlanningBoard.Model
{
    public interface ITaskRepository
    {
        int Add(Task task);
        void Delete(Task task);
        void Update(Task task);
        Task Get(int id);
        List<Task> List(int boardId);
        List<Task> List();
    }
}