using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.TreeLayerArchitecture.Entities
{
    public class Award
    {
        public string Title { get; set; }
        public Guid AwardId { get; private set; }
        private Award() => AwardId = Guid.NewGuid();
        public Award(string title) : this() => Title = title;
    }
    
}
