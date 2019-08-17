using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.Task2_3.OOP
{
    class UserMenu
    {
        User user;
        private bool exit;
        public void OpenMenu()
        {
            exit = false;
            do
            {
                Console.WriteLine("Please input munu item");
                var input = Console.ReadLine();
                if (int.TryParse(input, out int selectedMenuItem)
                && selectedMenuItem > 0
                && selectedMenuItem < 4)
                {
                    switch (selectedMenuItem)
                    {
                        case 0:
                            AddUser();
                            break;
                        case 1:
                            UpdateUser();
                            break;
                        case 2:
                            ShowUser();
                            break;
                        case 3:
                            Exit();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Select existing munu item");
                }
            }while (!exit);
        }
        private void ShowUser()
        {
            if (user == null)
            {
                Console.WriteLine("Error. Create user at first");
                return;
            }

            Console.WriteLine("First name: " + user.FirstName);
            Console.WriteLine("Last name: " + user.LastName);
            Console.WriteLine("Middle name: " + user.MiddleName);
            Console.WriteLine("Date of birth: {0:d}", user.BirthDate);
            Console.WriteLine("Age: " + user.Age);
        }

        private void UpdateUser()
        {
            if (user == null)
            {
                Console.WriteLine("Error. Create user at first");
                return;
            }

            Console.WriteLine("Update user data");

            Console.WriteLine("Previous first name: " + user.FirstName);
            Console.Write("New first name: ");
            user.FirstName = Console.ReadLine();

            Console.WriteLine("Previous last name: " + user.LastName);
            Console.Write("New last name: ");
            user.LastName = Console.ReadLine();

            Console.WriteLine("Previous middle name: " + user.MiddleName);
            Console.Write("New middle name: ");
            user.MiddleName = Console.ReadLine();

            Console.WriteLine("Previous date of birth: {0:d}", user.BirthDate);
            DateTime birthDate;
            string sBirthDate;
            do
            {
                Console.Write("New date of birth: ");
                sBirthDate = Console.ReadLine();
            }
            while (!DateTime.TryParse(sBirthDate, out birthDate));
            user.BirthDate = birthDate;
        }

        private void AddUser()
        {
            Console.WriteLine("Please input user data");
            Console.Write("First name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Middle name: ");
            string middleName = Console.ReadLine();
            DateTime birthDate;
            string sBirthDate;
            var ruCulture = new System.Globalization.CultureInfo("ru-RU");
            do
            {
                Console.Write("Date of birth: ");
                sBirthDate = Console.ReadLine();
            }
            while (!DateTime.TryParse(sBirthDate, ruCulture.DateTimeFormat, System.Globalization.DateTimeStyles.None, out birthDate));

            try
            {
                user = new User(firstName, lastName, middleName, birthDate);
            }
            catch
            {
                Console.WriteLine("Input values were wrong");
                Console.WriteLine("Returning to menu...");
                return;
            }
            Console.WriteLine("User added");
        }
        public void Exit()
        {
            exit = true;
        }
    }
}
