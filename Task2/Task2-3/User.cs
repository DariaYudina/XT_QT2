using System;
namespace Task2_3
{
    public class User
    {
        private string _lastname, _name, _middleName;
        private DateTime _birthday;
        private int _age;
        public User(string lastname, string name, string patronym, DateTime birthday, int age)
        {
            this._lastname = lastname;
            this._name = name;
            this._middleName = patronym;
            this._birthday = birthday;
            if (age > 0) { this._age = age; }
            else { throw new ArgumentException("Age can not be less than zero"); }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("LastName", "LastName must be neither null nor empty");
                }
                _name = value;
            }
        }
        public string Lastname
        {
            get { return _lastname; }
            set
            {
                if (String.IsNullOrEmpty(value))
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
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("LastName", "LastName must be neither null nor empty");
                }
                _middleName = value;
            }
        }
        public DateTime GetBirthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }
        public int GetAge { get { return _age; } set { _age = value; } }
        public override string ToString()
        {
            return $"Fullname: {_lastname} {_name} {_middleName}" + Environment.NewLine + $"Birthday: {_birthday.ToShortDateString()}" + Environment.NewLine + $"Age: {_age}";
        }
        public virtual void GetInfo()
        {
            Console.WriteLine($"Fullname: {_lastname} {_name} {_middleName}" +
                Environment.NewLine + $"Birthday: {_birthday.ToShortDateString()}" +
                Environment.NewLine + $"Age: {_age}");
        }
    }
}
