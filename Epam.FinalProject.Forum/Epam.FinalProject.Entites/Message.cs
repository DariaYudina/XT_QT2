using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FinalProject.Entites
{
    public class Message
    {
        #region Fields

        private string text;

        #endregion Fields
        #region Constructors
        public Message() { }
        public Message(int messageId, int userId, int topicId, DateTime datecreation, string text) : this()
        {
            MessageId = messageId;
            UserId = userId;
            TopicId = topicId;
            DateCreation = datecreation;
            Text = text;
        }
        #endregion Constructors
        #region Properties
        public int MessageId { get; set; }
        public int UserId { get; set; }
        public int TopicId { get; set; }
        public DateTime DateCreation { get; set; }
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

        #endregion Properties
    }
}
