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
    public class UserBLL
    {
        #region Fields
        private static UserBLL instance;
        public static UserBLL getInstance()
        {
            if (instance == null)
                instance = new UserBLL();
            return instance;
        }

        public  IStorableUser MemoryStorageUser => Dependensies.MemoryStorageUser;
        #endregion Fields
        #region Constructors
        private UserBLL()
        { }
        #endregion Constructors
        #region Methods
        public bool AddUser(string name, DateTime birthDate)
        {          
            if ( MemoryStorageUser.AddUser(new User(name, birthDate)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public  void AddUser(User user)
        {
            MemoryStorageUser.AddUser(user);
        }
        public  bool AddAward(Guid userId, Award award)
        {
            if (MemoryStorageUser.AddAwards(userId, new List<Award> { award }))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public  bool AddAwards(Guid userId,List<Award> awards)
        {
            if (MemoryStorageUser.AddAwards(userId, awards))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public  bool DeleteUser(User user)
        {
            if (MemoryStorageUser.Delete(user.UserId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public  IEnumerable<User> GetAllUsers()
        {
            return MemoryStorageUser.GetAllUsers();
        }
        #endregion Methods
    }
}
