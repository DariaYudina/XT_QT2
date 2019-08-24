using Epam.TreeLayerArchitecture.AbstractDAL;
using Epam.TreeLayerArchitecture.ConfigDAL;
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
        private static AwardBLL instance;
        public static AwardBLL getInstance()
        {
            if (instance == null)
                instance = new AwardBLL();
            return instance;
        }
        public  IStorableAward Awards => Dependensies.MemoryStorageAward;

        #endregion Fields
        #region Constructors
        private AwardBLL()
        { }
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
            if (Awards.DeleteAward(award.AwardId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public IEnumerable<Award> GetAllAwards()
        {
            return Awards.GetAllAwards();
        }
        #endregion Methods
    }
}
