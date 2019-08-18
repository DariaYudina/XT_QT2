using Epam.TreeLayerArchitecture.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.TreeLayerArchitecture.AbstractDAL
{
    public interface IStorableAward
    {
        bool AddAward(Award award);
        bool DeleteAward(Guid awardId);
        Award GetAward(Guid awardId);
        ICollection<Award> GetAllAwards();
    }
}
