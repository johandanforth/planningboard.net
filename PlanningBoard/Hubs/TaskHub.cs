using System.Diagnostics;
using Microsoft.AspNet.SignalR;
using PlanningBoard.Model;
using Task = System.Threading.Tasks.Task;

namespace PlanningBoard.Hubs
{
    public class TaskHub : Hub
    {
        private ITaskRepository _taskRepository;

        public TaskHub()
        {
            _taskRepository = new TaskRepository();
        }

        public void Delete(int id)
        {
            Trace.WriteLine("deleted: " + id);
            Clients.All.deleted(id);
        } 
        
        public void Add(int id)
        {
            Trace.WriteLine("added: " + id);
            Clients.All.added(id);
        }

        public void Update(int id)
        {
            Trace.WriteLine("updated: " + id);
            Clients.All.updated(id);
        }

        public override Task OnConnected()
        {
            Trace.TraceInformation("Client {0} connected", Context.ConnectionId);
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            Trace.TraceInformation("Client {0} disconnected", Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            Trace.TraceInformation("Client {0} reconnected", Context.ConnectionId);
            return base.OnReconnected();
        }

    }
}