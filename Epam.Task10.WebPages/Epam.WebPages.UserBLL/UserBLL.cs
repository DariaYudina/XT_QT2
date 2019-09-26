using Epam.WebPages.AbstractDAL;
using Epam.WebPages.DAL;
using Epam.WebPages.Entities;
using Epam.WebPages.AbsractBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

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
        public bool AddUser(string name, DateTime birthDate, string avatar, string password)
        {
            return (_userDao.AddUser(new User(name, birthDate, avatar, ComputeHash(password, new MD5CryptoServiceProvider()))));
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

        public bool DeleteAward(Guid userId, Guid awardid)
        {
            return _userDao.DeleteAward(userId, awardid);
        }

        public void DeleteUsersAward(Guid awardId)
        {
            _userDao.DeleteUsersAward(awardId);
        }
        private string ComputeHash(string input, HashAlgorithm algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);

            return BitConverter.ToString(hashedBytes);
        }
        public bool VerifyUser(string login, string password)
        {
            var user = GetAllUsers().FirstOrDefault(x => x.Name == login);
            if (user != null)
            {
                return user.Password == ComputeHash(password, new MD5CryptoServiceProvider());
            }

            return false;
        }
        #endregion Methods
    }
}
