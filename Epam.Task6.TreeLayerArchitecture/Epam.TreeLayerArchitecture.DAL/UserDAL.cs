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
            if (this.GetUser(user.UserId) != null)
            {
                return false;
            }
            users.Add(user.UserId, user);
            return true;
        }
        public bool Delete(Guid userId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Entities.User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public User GetUser(Guid userId)
        {
            User user;
            bool isSuccess = this.users.TryGetValue(userId, out user);
            return isSuccess ? user : null;
        }
    }
}
