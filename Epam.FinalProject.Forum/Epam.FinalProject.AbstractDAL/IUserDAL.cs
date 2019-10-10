using Epam.FinalProject.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FinalProject.AbstractDAL
{
    public interface IUserDAL
    {
        bool AddUser(string name, DateTime birthDate, string avatar, string password, string role);
        IEnumerable<User> GetAllUsers();
        User GetUser(int id);
    }
}
