using Epam.FinalProject.AbstractBLL;
using Epam.FinalProject.AbstractDAL;
using Epam.FinalProject.DAL;
using Epam.FinalProject.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FinalProject.BLL
{
    public class UserLogic : IUserBLL
    {
        #region Fields
        private readonly IUserDAL _userDao;
        #endregion Fields

        #region Constructors
        public UserLogic(IUserDAL userDao)
        {
            _userDao = userDao;
        }

        #endregion Constructors

        #region Methods
        public bool AddUser(string name, DateTime birthDate, string avatar, string password, string role)
        {
            return (_userDao.AddUser(name, birthDate, avatar, ComputeHash(password, new MD5CryptoServiceProvider()), role));
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userDao.GetAllUsers();
        }

        public User GetUser(int id)
        {
            return _userDao.GetUser(id);
        }

        public User VerifyUser(string login, string password)
        {
            var user = GetAllUsers().FirstOrDefault(x => x.Name == login);
            if (user != null && user.Password == ComputeHash(password, new MD5CryptoServiceProvider()))
            {              
                return user;
            }

            return null;
        }
        private string ComputeHash(string input, HashAlgorithm algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);

            return BitConverter.ToString(hashedBytes);
        }
        #endregion Methods
    }
}
