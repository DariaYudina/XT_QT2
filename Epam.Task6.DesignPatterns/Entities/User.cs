using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Entities
{
    public class User
    {
        public Guid Id { get; private set; }

        public string Text { get; private set; }

        public DateTime CreationTime { get; set; }

        public void ChangeText(string newText)
        {
            Text = newText;
        }

        public User(string content)
        {
            Id = Guid.NewGuid();

            Text = content;
        }
    }
}
