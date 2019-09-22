using Epam.WebPages.Common;
using Epam.WebPages.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.WebPages.UIweb.Models
{
    public static class AwardModel
    {
        public static IEnumerable<Award> GetAllAwards()
        {
            return DependencyResolver.AwardLogic.GetAllAwards();
        }
        public static void AddAward(string title)
        {
            DependencyResolver.AwardLogic.AddAward(title);
        }
        public static bool DeleteAward(string id)
        {
            return DependencyResolver.AwardLogic.DeleteAward(Guid.Parse(id));
        }
    }
}