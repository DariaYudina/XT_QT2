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
        private static readonly IUserBLL _userLogic;
        private static readonly IUserDAL _userDao;

        private static readonly IForumBLL _forumLogic;
        private static readonly IForumDAL _forumDao;
        public static IUserBLL UserLogic => _userLogic;
        public static IUserDAL UserDao => _userDao;
        public static IForumBLL ForumLogic => _forumLogic;
        public static IForumDAL ForumDao => _forumDao;
        static DependencyResolver()
        {
            _userDao = new UserDao();
            _userLogic = new UserLogic(_userDao);

            _forumDao = new ForumDao();
            _forumLogic = new ForumLogic(_forumDao);
        }
    }
}
