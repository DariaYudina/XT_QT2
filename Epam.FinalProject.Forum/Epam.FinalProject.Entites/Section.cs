using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.FinalProject.Entites
{
    public class Section
    {
        #region Fields

        private string title;

        #endregion Fields
        #region Constructors
        public Section() { }
        public Section(int sectionId, string title) : this()
        {
            SectionId = sectionId;
            Title = title;
        }
        #endregion Constructors
        #region Properties
        public int SectionId { get; set; }
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
        #endregion Properties
    }
}
