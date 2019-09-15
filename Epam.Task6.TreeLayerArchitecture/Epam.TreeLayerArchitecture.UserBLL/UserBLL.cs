using Epam.TreeLayerArchitecture.AbstractDAL;
using Epam.TreeLayerArchitecture.DAL;
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
        private IStorableUser _userDao;
        #endregion Fields
        #region Constructors
        public UserBLL()
        {
            _userDao = new UserDAL();
        }
        #endregion Constructors
        #region Methods
        public bool AddUser(string name, DateTime birthDate)
        {          
            if (_userDao.AddUser(new User(name, birthDate)))
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
            _userDao.AddUser(user);
        }
        public  bool AddAward(Guid userId, Award award)
        {
            if (_userDao.AddAwards(userId, new List<Award> { award }))
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
            if (_userDao.AddAwards(userId, awards))
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
            if (_userDao.Delete(user.UserId))
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
            return _userDao.GetAllUsers();
        }
        #endregion Methods
    }
}
