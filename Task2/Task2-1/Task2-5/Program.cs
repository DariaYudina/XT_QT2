using System;
using Task2_3;
namespace Task2_5
{
    class Program
    {
        static void Main(string[] args)
        {
            User u = new User("Иванов","Иван", "Иванович", new DateTime(2015, 7, 20), 23);
            Employee e = new Employee("Петров", "Иван", "Иванович", new DateTime(2015, 7, 20), 23, 3, "Software engineer");
            Console.WriteLine(e);
            Console.ReadLine();
        }
    }
    public class Employee : User
    {
        private int _workExperience;
        private string _position;
        public int GetWorkExperience { get { return _workExperience; } }
        public string GetPosition { get { return _position; } }
        public Employee(string lastname, string name, string patronym, DateTime birthday, int age, int workExperience, string position) :base(lastname, name, patronym, birthday, age)
        {
        this._workExperience = workExperience;
        this._position = position;
        }
        public override string ToString()
        {
            return $"Fullname: {this.GetLastname} {this.GetName} {this.GetPartonym}" +
                Environment.NewLine + $"Birthday: {this.GetBirthday.ToShortDateString()}" + 
                Environment.NewLine + $"Age: {this.GetAge}"+
                Environment.NewLine + $"WorkExperience: {_workExperience}"+
                Environment.NewLine + $"Position: {_position}"
                ;

        }
        public override void GetInfo()
        {
            Console.WriteLine($"Fullname: {this.GetLastname} {this.GetName} {this.GetPartonym}" +
                Environment.NewLine + $"Birthday: {this.GetBirthday.ToShortDateString()}" +
                Environment.NewLine + $"Age: {this.GetAge}" +
                Environment.NewLine + $"WorkExperience: {_workExperience}" +
                Environment.NewLine + $"Position: {_position}");
        }
    }
}
