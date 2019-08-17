using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.TreeLayerArchitecture.Entities
{
    public class User
    {
        private string name;
        private DateTime birthDate;
        public Guid UserId { get; private set; }
        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrEmpty(value))
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

        public User()
        {
            UserId = Guid.NewGuid();
        }
        public User(string name, DateTime birthDate) : this()
        {
            Name = name;
            BirthDate = birthDate;
        }
    }
}
