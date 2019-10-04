using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.WebPages.Entities
{
    public class Award : IEquatable<Award>
    {
        private string title; 
        public Guid AwardId { get; set; }
        public string Image { get; set; } = "";
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
        public Award(string title, string image) 
        {
            Title = title;
            Image = image;
        }

        public bool Equals(Award other)
        {
            if (other is null)
                return false;
            return Title == other.Title && AwardId == other.AwardId;
        }
        public override bool Equals(object obj) => Equals(obj as Award);
        public override int GetHashCode() => (Title, AwardId).GetHashCode();       
    }
}
