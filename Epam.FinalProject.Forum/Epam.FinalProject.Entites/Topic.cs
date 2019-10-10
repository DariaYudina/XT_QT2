using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FinalProject.Entites
{
    public class Topic
    {
        #region Fields

        private string title;

        #endregion Fields
        #region Constructors
        public Topic() { }
        public Topic(int topicId, int sectionId, string title) : this()
        {
            Title = title;
            TopicId = topicId;
            SectionId = sectionId;
        }
        #endregion Constructors
        #region Properties
        public string Title
        {
            get => title;
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Title", "Title must be neither null nor empty");
                }
                title = value;
            }
        }
        public int TopicId { get; set; }
        public int SectionId { get; set; }
        #endregion Properties
    }
}
