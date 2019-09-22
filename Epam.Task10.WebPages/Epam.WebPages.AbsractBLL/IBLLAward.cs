using Epam.WebPages.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.WebPages.AbsractBLL
{
    public interface IBLLAward
    {
        bool AddAward(string title);
        void AddAward(Award user);
        bool DeleteAward(Guid awardId);
        IEnumerable<Award> GetAllAwards();
    }
}
