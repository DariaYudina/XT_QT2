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
        private static readonly IBLL _appLogic;
        private static readonly IDAL _appDao;
        public static IBLL AppLogic => _appLogic;
        public static IDAL AppDao => _appDao;
        static DependencyResolver()
        {
            _appDao = new AppDao();
            _appLogic = new AppLogic(_appDao);
        }
    }
}
