using Epam.WebPages.Common;
using Epam.WebPages.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.WebPages.UIweb.Models
{
    public static class UserModel
    {
        public static IEnumerable<User> GetAllUsers()
        {
            return DependencyResolver.UsersLogic.GetAllUsers();
        }
        public static void AddUser(string name, DateTime birthDate)
        {
            DependencyResolver.UsersLogic.AddUser(name, birthDate);
        }
        public static bool DeleteUser(string id)
        {
            return DependencyResolver.UsersLogic.DeleteUser(Guid.Parse(id));
        }
        public static bool AddAward(Guid userid, Award award)
        {
            return DependencyResolver.UsersLogic.AddAward(userid, award);
        }
    }
}