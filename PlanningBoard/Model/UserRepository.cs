using System.Linq;
using Dapper;

namespace PlanningBoard.Model
{
    public class UserRepository : BaseRepository, IUserRerpository
    {
        public User GetUser(string username)
        {
            using (var cnn = GetDbConnection())
            {
                return
                    cnn.Query<User>("select * from Users where username = @username", new {username}).FirstOrDefault();
            }
        }
    }
}