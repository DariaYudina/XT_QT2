using Epam.WebPages.AbsractBLL;
using Epam.WebPages.AbstractDAL;
using Epam.WebPages.DAL;
using Epam.WebPages.BLL;
using Epam.WebPages.DataBaseDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.WebPages.Common
{
    public static class DependencyResolver
    {
        private static readonly IBLLUser _usersLogic;
        private static readonly IStorableUser _usersDao;

        private static readonly IBLLAward _awardLogic;
        private static readonly IStorableAward _awardDao;
        public static IBLLUser UsersLogic => _usersLogic;
        public static IBLLAward AwardLogic => _awardLogic;
        public static IStorableUser UsersDao => _usersDao;
        public static IStorableAward AwardsDao => _awardDao;
        static DependencyResolver()
        {
            _usersDao = new UserDao();
            _usersLogic = new UserBLL(_usersDao);
            _awardDao = new AwardDAL();
            _awardLogic = new AwardBLL(_awardDao);
        }
    }
}
