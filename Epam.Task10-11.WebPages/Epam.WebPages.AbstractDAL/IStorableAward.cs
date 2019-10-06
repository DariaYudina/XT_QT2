using Epam.WebPages.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.WebPages.AbstractDAL
{
    public interface IStorableAward
    {
        bool AddAward(Award award);
        bool DeleteAward(Guid awardId);
        Award GetAward(Guid awardId);
        IEnumerable<Award> GetAllAwards();
    }
}
