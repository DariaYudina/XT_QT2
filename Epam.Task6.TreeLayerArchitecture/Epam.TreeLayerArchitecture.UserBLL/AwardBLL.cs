using Epam.TreeLayerArchitecture.AbstractDAL;
using Epam.TreeLayerArchitecture.DAL;
using Epam.TreeLayerArchitecture.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.TreeLayerArchitecture.UserBLL
{
    public class AwardBLL
    {
        #region Fields
        private IStorableAward Awards;
        #endregion Fields
        #region Constructors
        public AwardBLL()
        {
            Awards = new AwardDAL();
        }
        #endregion Constructors
        #region Methods
        public bool AddAward(string title)
        {
            if (Awards.AddAward(new Award(title)))
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
            Awards.AddAward(user);
        }
        public  bool DeleteAward(Award award)
        {
           return Awards.DeleteAward(award.AwardId);
        }
        public IEnumerable<Award> GetAllAwards()
        {
            return Awards.GetAllAwards();
        }
        #endregion Methods
    }
}
