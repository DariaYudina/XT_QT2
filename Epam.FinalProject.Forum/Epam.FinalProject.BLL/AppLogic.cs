using Epam.FinalProject.AbstractBLL;
using Epam.FinalProject.AbstractDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FinalProject.BLL
{
    public class AppLogic : IBLL
    {
        private readonly IDAL _dao;
        public AppLogic(IDAL dao)
        {
            _dao = dao;
        }
    }
}
