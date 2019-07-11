using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_3
{
    public class User
    {
        private string _lastname, _name, _patronym;
        private DateTime _birthday;
        private int _age;
        public User(string lastname, string name, string patronym, DateTime birthday, int age)
        {
            this._lastname = lastname;
            this._name = name;
            this._patronym = patronym;
            this._birthday = birthday;
            if (age > 0) { this._age = age; }
            else { throw new ArgumentException("Age can not be less than zero"); }
        }
        public string GetName { get { return _name; } set { _name = value; } }
        public string GetLastname { get { return _lastname; } set { _lastname = value; } }
        public string GetPartonym { get { return _patronym; } }
        public DateTime GetBirthday { get { return _birthday; } }
        public int GetAge { get { return _age; } }
        public override string ToString()
        {
            return $"Fullname: {_lastname} {_name} {_patronym}" + Environment.NewLine + $"Birthday: {_birthday.ToShortDateString()}" + Environment.NewLine + $"Age: {_age}";
        }
        public virtual void GetInfo()
        {
            Console.WriteLine($"Fullname: {_lastname} {_name} {_patronym}" +
                Environment.NewLine + $"Birthday: {_birthday.ToShortDateString()}" +
                Environment.NewLine + $"Age: {_age}");
        }
    }
}
