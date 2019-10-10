using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FinalProject.Entites
{
    public class Massage
    {
        #region Fields

        private string text;

        #endregion Fields
        #region Constructors
        public Massage() { }
        public Massage(int massageId, int sectionId, int topicId, string text) : this()
        {
            MassageId = massageId;
            SectionId = sectionId;
            TopicId = topicId;
            Text = text;
        }
        #endregion Constructors
        #region Properties
        public string Text
        {
            get => text;
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Text", "Text must be neither null nor empty");
                }
                text = value;
            }
        }
        public int  MassageId { get; set; }
        public int SectionId { get; set; }
        public int TopicId { get; set; }
        #endregion Properties
    }
}
