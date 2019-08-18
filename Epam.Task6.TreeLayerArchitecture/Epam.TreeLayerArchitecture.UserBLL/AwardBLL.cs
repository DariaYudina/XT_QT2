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
        public static IStorableAward Awards => Dependensies.MemoryStorageAward;
        public static bool AddAward(string title)
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
        public static void AddAward(Award user)
        {
            Awards.AddAward(user);
        }
        public static bool DeleteAward(Award user)
        {
            if (Awards.Delete(user.userId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static ICollection<Award> GetAllAwards()
        {
            return Awards.GetAllAwards();
        }
    }
}
