using Epam.TreeLayerArchitecture.AbstractDAL;
using Epam.TreeLayerArchitecture.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.TreeLayerArchitecture.ConfigDAL
{
    public static class Dependensies
    {
        public static IStorableUser MemoryStorageUser { get; } = new UserDAL();
        public static IStorableAward MemoryStorageAward { get; } = new AwardDAL();
    }
}
