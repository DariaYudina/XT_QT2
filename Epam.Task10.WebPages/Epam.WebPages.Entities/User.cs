using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.WebPages.Entities
{
    public class User
    {
        #region Fields
        private string name;
        private DateTime birthDate;
        public Guid UserId { get; set; }
        public List<Award> Awards { get; set; }
        public string Avatar { get; set; } = "";
        #endregion Fields
        #region Constructors
        public User()
        {
            UserId = Guid.NewGuid();
            Awards = new List<Award>();
        }
        public User(string name, DateTime birthDate) : this()
        {
            Name = name;
            BirthDate = birthDate;
        }
        public User(string name, DateTime birthDate, string avatar) : this()
        {
            Name = name;
            BirthDate = birthDate;
            Avatar = avatar;
        }
        public User(string name, DateTime birthDate, List<Award> awards, string avatar)
        : this(name, birthDate)
        {
            Awards = awards;
            Avatar = avatar;
        }
        #endregion Constructors
        #region Properties
        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name", "Name must be neither null nor empty");
                }
                name = value;
            }
        }
        public DateTime BirthDate
        {
            get => birthDate;
            set
            {
                if (value >= DateTime.Now || value.AddYears(150) < DateTime.Now)
                {
                    throw new ArgumentException("Birthdate", "BirthDate must be less than today and greater than 150 yers");
                }
                birthDate = value;
            }
        }
        public int Age
        {
            get
            {
                DateTime date = DateTime.Now;
                int age = date.Year - BirthDate.Year;
                return (date.Month >= this.BirthDate.Month && date.Day >= BirthDate.Day) ? age : age - 1;
            }
        }
        #endregion Properties
    }
}
