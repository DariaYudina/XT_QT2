using Epam.FinalProject.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FinalProject.AbstractBLL
{
    public interface IUserBLL
    {
        bool AddUser(string name, DateTime birthDate, string avatar, string password, string role);
        IEnumerable<User> GetAllUsers();
        User VerifyUser(string login, string password);
        User GetUser(int id);
    }
}
