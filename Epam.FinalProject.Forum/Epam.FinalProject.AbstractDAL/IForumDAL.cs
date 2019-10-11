using Epam.FinalProject.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FinalProject.AbstractDAL
{
    public interface IForumDAL
    {
        bool AddSection(string title);
        IEnumerable<Section> GetAllSections();
        bool AddTopic(int sectionId, string title);
        IEnumerable<Topic> GetSectionTopics(int sectionId);
        IEnumerable<Message> GetTopicMessages(int topicId);
    }
}
