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
        bool AddAward(Award user);
        bool DeleteAward(Guid userId);
        Award GetAward(Guid userId);
        ICollection<Award> GetAllAwards();
    }
}
