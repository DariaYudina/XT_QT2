using Epam.FinalProject.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FinalProject.AbstractBLL
{
    public interface IForumBLL
    {
        bool AddSection(string title);
        IEnumerable<Section> GetAllSections();
        IEnumerable<Topic> GetSectionTopics(int sectionId);
    }
}
