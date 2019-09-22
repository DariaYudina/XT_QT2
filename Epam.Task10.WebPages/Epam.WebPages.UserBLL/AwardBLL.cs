using Epam.WebPages.DAL;
using Epam.WebPages.AbstractDAL;
using Epam.WebPages.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.WebPages.AbsractBLL;

namespace Epam.WebPages.BLL
{
    public class AwardBLL : IBLLAward
    {
        #region Fields
        private IStorableAward _awardsDao;
        #endregion Fields
        #region Constructors
        public AwardBLL(IStorableAward awardsDao)
        {
            _awardsDao = awardsDao;
        }
        #endregion Constructors
        #region Methods
        public bool AddAward(string title)
        {
            if (_awardsDao.AddAward(new Award(title)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void AddAward(Award user)
        {
            _awardsDao.AddAward(user);
        }
        public  bool DeleteAward(Guid awardId)
        {
           return _awardsDao.DeleteAward(awardId);
        }
        public IEnumerable<Award> GetAllAwards()
        {
            return _awardsDao.GetAllAwards();
        }
        #endregion Methods
    }
}
