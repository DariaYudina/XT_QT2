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
        bool AddTopic(int sectionId, string title);
        bool AddMessage(int topicId, int userId, DateTime datecreation, string text);
        IEnumerable<Section> GetAllSections();
        IEnumerable<Topic> GetSectionTopics(int sectionId);
        IEnumerable<Message> GetTopicMessages(int topicId);
    }
}
