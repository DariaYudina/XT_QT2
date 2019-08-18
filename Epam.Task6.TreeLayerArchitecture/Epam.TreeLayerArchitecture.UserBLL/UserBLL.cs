using Epam.TreeLayerArchitecture.AbstractDAL;
using Epam.TreeLayerArchitecture.ConfigDAL;
using Epam.TreeLayerArchitecture.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.TreeLayerArchitecture.UserBLL
{
    public static class UserBLL
    {
        public static IStorableUser MemoryStorage => Dependensies.MemoryStorage;

        public static bool AddUser(string name, DateTime birthDate)
        {          
            if ( MemoryStorage.AddUser(new User(name, birthDate)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void AddUser(User user)
        {
            MemoryStorage.AddUser(user);
        }
        public static bool DeleteUser(User user)
        {
            if (MemoryStorage.Delete(user.userId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static ICollection<User> GetAllUsers()
        {
            return MemoryStorage.GetAllUsers();
        }
    }
}
