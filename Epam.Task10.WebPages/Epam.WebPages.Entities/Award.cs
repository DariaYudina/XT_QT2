using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.WebPages.Entities
{
    public class Award
    {
        private string title; 
        public Guid AwardId { get; set; }
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
        public Award() => AwardId = Guid.NewGuid();
        public Award(string title) : this() => Title = title;
    }

}
