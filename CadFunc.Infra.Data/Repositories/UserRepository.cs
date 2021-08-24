using CadFunc.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CadFunc.Infra.Data.Repositories
{
    public static class UserRepository
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, Username = "batman", Password = "batman"});
            users.Add(new User { Id = 2, Username = "robin", Password = "robin" });
            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrDefault();
        }
    }
}
