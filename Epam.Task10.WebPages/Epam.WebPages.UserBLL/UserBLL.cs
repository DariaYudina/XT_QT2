using Epam.WebPages.AbstractDAL;
using Epam.WebPages.DAL;
using Epam.WebPages.Entities;
using Epam.WebPages.AbsractBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.WebPages.BLL
{
    public class UserBLL : IBLLUser
    {
        #region Fields
        private readonly IStorableUser _userDao;

        #endregion Fields
        #region Constructors
        public UserBLL(IStorableUser userDao)
        {
            _userDao = userDao;
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
        public bool AddAward(Guid userId, Award award)
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
        //public  bool DeleteUser(User user)
        //{
        //    if (_userDao.Delete(user.UserId))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        public bool DeleteUser(Guid userId)
        {
            if (_userDao.Delete(userId))
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
