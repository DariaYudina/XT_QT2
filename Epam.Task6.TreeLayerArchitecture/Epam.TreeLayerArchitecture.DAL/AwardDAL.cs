using Epam.TreeLayerArchitecture.AbstractDAL;
using Epam.TreeLayerArchitecture.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Epam.TreeLayerArchitecture.DAL
{
    public class AwardDAL : IStorableAward
    {
        private Dictionary<Guid, Award> awards;
        public AwardDAL()
        {
            awards = new Dictionary<Guid, Award>();
        }

        public bool AddAward(Award award)
        {
            awards.Add(award.AwardId, award);
            return true;
        }

        public bool DeleteAward(Guid awardId)
        {
            if (awards.ContainsKey(awardId))
            {
                awards.Remove(awardId);
                return true;
            }
            else
            {
                return false;
            }
        }

        public ICollection<Award> GetAllAwards()
        {
            return awards.Values.ToList();
        }

        public Award GetAward(Guid awardId)
        {
            bool isSuccess = this.awards.TryGetValue(awardId, out Award award);
            return isSuccess ? award : null;
        }
    }
}
