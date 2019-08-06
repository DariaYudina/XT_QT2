using System;

namespace Epam.Task2.Task2_3.OOP
{
    public class User
    {
        private string _lastname, _firstname, _middleName;
        private DateTime _birthday;
        public User(string lastname, string firstname, string patronym, DateTime birthday)
        {
            _lastname = lastname;
            _firstname = firstname;
            _middleName = patronym;
            _birthday = birthday;
        }
        public string FirstName
        {
            get { return _firstname; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("LastName", "LastName must be neither null nor empty");
                }
                _firstname = value;
            }
        }
        public string LastName
        {
            get { return _lastname; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("LastName", "LastName must be neither null nor empty");
                }
                _lastname = value;
            }
        }
        public string MiddleName
        {
            get { return _middleName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("LastName", "LastName must be neither null nor empty");
                }
                _middleName = value;
            }
        }
        public DateTime BirthDate
        {
            get { return _birthday; }
            set
            {
                if (value > DateTime.Now || value.AddYears(150) < DateTime.Now)
                {
                    throw new ArgumentOutOfRangeException(
                        "Birthday",
                        "BirthDate must be less than today and greater than");
                }
                _birthday = value;
            }
        }
        public int Age
        {
            get
            {
                DateTime now = DateTime.Now;
                int age = now.Year - _birthday.Year;
                return _birthday.Month <= now.Month && _birthday.Day <= now.Day ? age : age - 1;
            }
        }
        public override string ToString()
        {
            return $"Fullname: {_lastname} {_firstname} {_middleName}" + Environment.NewLine + $"Birthday: {_birthday.ToShortDateString()}" + Environment.NewLine + $"Age: {_age}";
        }
        public virtual void GetInfo()
        {
            Console.WriteLine($"Fullname: {_lastname} {_firstname} {_middleName}" +
                Environment.NewLine + $"Birthday: {_birthday.ToShortDateString()}" +
                Environment.NewLine + $"Age: {_age}");
        }
    }
}
