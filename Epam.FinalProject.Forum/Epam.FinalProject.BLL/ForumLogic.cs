using Epam.FinalProject.AbstractBLL;
using Epam.FinalProject.AbstractDAL;
using Epam.FinalProject.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FinalProject.BLL
{
    public class ForumLogic : IForumBLL
    {
        #region Fields
        private readonly IForumDAL _forumDao;
        #endregion Fields
        #region Constructors
        public ForumLogic(IForumDAL forumDao)
        {
            _forumDao = forumDao;
        }

        public bool AddMessage(int topicId, int userId, DateTime datecreation, string text)
        {
            return _forumDao.AddMessage(topicId, userId, datecreation, text);
        }

        #endregion Constructors
        #region Methods
        public bool AddSection(string title)
        {
            return _forumDao.AddSection(title);
        }

        public bool AddTopic(int sectionId, string title)
        {
            return _forumDao.AddTopic(sectionId, title);
        }

        public IEnumerable<Section> GetAllSections()
        {
            return _forumDao.GetAllSections();
        }

        public IEnumerable<Topic> GetSectionTopics(int sectionId)
        {
            return _forumDao.GetSectionTopics(sectionId);
        }

        public IEnumerable<Message> GetTopicMessages(int topicId)
        {
            return _forumDao.GetTopicMessages(topicId);
        }
        #endregion Methods
    }
}
