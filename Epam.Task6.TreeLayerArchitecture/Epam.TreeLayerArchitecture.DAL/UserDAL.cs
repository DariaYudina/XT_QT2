using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.TreeLayerArchitecture.AbstractDAL;
using Epam.TreeLayerArchitecture.Entities;


namespace Epam.TreeLayerArchitecture.DAL
{
    public class UserDAL : IStorableUser
    {
        private Dictionary<Guid, User> users;
        public UserDAL()
        {
            users = new Dictionary<Guid, User>();
        }
        public bool AddUser(User user)
        {
            if (this.GetUser(user.userId) != null)
            {
                return false;
            }
            users.Add(user.userId, user);
            return true;
        }
        public bool Delete(Guid userId)
        {
            if (users.ContainsKey(userId))
            {
                users.Remove(userId);
                return true;
            }
            else
            {
                return false;
            }
        }

        public ICollection<User> GetAllUsers()
        {
            return users.Values.ToList();
        }

        public User GetUser(Guid userId)
        {
            User user;
            bool isSuccess = this.users.TryGetValue(userId, out user);
            return isSuccess ? user : null;
        }
    }
}
