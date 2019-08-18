using Epam.TreeLayerArchitecture.AbstractDAL;
using Epam.TreeLayerArchitecture.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.TreeLayerArchitecture.DAL
{
    public class AwardDAL : IStorableAward
    {
        private Dictionary<Guid, Award> awards;
        public AwardDAL()
        {
            awards = new Dictionary<Guid, Award>();
        }

        public bool AddAward(Award user)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAward(Guid userId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Award> GetAllAwards()
        {
            throw new NotImplementedException();
        }

        public Award GetAward(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
