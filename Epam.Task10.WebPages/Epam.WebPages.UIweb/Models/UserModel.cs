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
    }
}