using Epam.FinalProject.Common;
using Epam.FinalProject.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.FinalProject.Forum.Models
{
    public static class ForumModel
    {
        public static bool AddSection(string title)
        {
            return DependencyResolver.ForumLogic.AddSection(title);
        }
        public static IEnumerable<Section> GetAllSections()
        {
            return DependencyResolver.ForumLogic.GetAllSections();
        }
        public static IEnumerable<Topic> GetSectionTopics(int sectionId)
        {
            return DependencyResolver.ForumLogic.GetSectionTopics(sectionId);
        }
        public static bool AddTopic(int sectionId, string title)
        {
            return DependencyResolver.ForumLogic.AddTopic(sectionId, title);
        }
        public static Topic TopicByIdAndSectionId(int sectionId, int topicId)
        {
            return GetSectionTopics(sectionId).FirstOrDefault(x => x.TopicId == topicId);
        }
        public static IEnumerable<Message> GetTopicMessages(int TopicId)
        {
            return DependencyResolver.ForumLogic.GetTopicMessages(TopicId);
        }      
    }
}