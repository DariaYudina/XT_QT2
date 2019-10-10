using Epam.FinalProject.AbstractBLL;
using Epam.FinalProject.AbstractDAL;
using Epam.FinalProject.BLL;
using Epam.FinalProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FinalProject.Common
{
    public static class DependencyResolver
    {
        private static readonly IUserBLL _appLogic;
        private static readonly IUserDAL _appDao;
        public static IUserBLL AppLogic => _appLogic;
        public static IUserDAL AppDao => _appDao;
        static DependencyResolver()
        {
            _appDao = new UserDao();
            _appLogic = new UserLogic(_appDao);
        }
    }
}
