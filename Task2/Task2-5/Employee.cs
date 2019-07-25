using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_3;

namespace Task2_5
{
    class Employee : User
    {
        private int _workExperience;
        private string _position;
        public int GetWorkExperience { get { return _workExperience; } }
        public string GetPosition { get { return _position; } }
        public Employee(string lastname, string name, string patronym, DateTime birthday, int age, int workExperience, string position) : base(lastname, name, patronym, birthday)
        {
            this._workExperience = workExperience;
            this._position = position;
        }
        public override string ToString()
        {
            return $"Fullname: {this.LastName} {this.FirstName} {this.MiddleName}" +
                Environment.NewLine + $"Birthday: {this.BirthDate.ToShortDateString()}" +
                Environment.NewLine + $"Age: {this.Age}" +
                Environment.NewLine + $"WorkExperience: {_workExperience}" +
                Environment.NewLine + $"Position: {_position}"
                ;

        }
        public override void GetInfo()
        {
            Console.WriteLine($"Fullname: {this.LastName} {this.FirstName} {this.MiddleName}" +
                Environment.NewLine + $"Birthday: {this.BirthDate.ToShortDateString()}" +
                Environment.NewLine + $"Age: {this.Age}" +
                Environment.NewLine + $"WorkExperience: {_workExperience}" +
                Environment.NewLine + $"Position: {_position}");
        }
    }
}
