using Epam.TreeLayerArchitecture.Entities;
using Epam.TreeLayerArchitecture.UserBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.TreeLayerArchitecture.PL
{
    public class AppMenu
    {
        private bool exit;
        public void OpenMenu()
        {
            exit = false;
            do
            {
                Console.WriteLine($"Please select some action:{Environment.NewLine}" +
                                     $"1. Add User{Environment.NewLine}" +
                                     $"2. Delete User{Environment.NewLine}" +
                                     $"3. Show all users{Environment.NewLine}" +
                                     $"4. Exit{Environment.NewLine}" +
                                     "");
                var input = Console.ReadLine();
                if (int.TryParse(input, out int selectedOption)
                    && selectedOption > 0
                    && selectedOption < 4)
                {
                    switch (selectedOption)
                    {
                        case 1:
                            AddUser();
                            break;
                        case 2:
                            ShowNotes(UserBLL.UserBLL.GetAllUsers());
                            break;
                        case 3:

                            break;
                        case 4:
                            exit = true; break;
                    }
                }
                else
                {
                    Console.WriteLine("Input correct menu item");
                }
            } while (!exit);
        }
        private void AddUser()
        {
            Console.WriteLine("input name:");
            string name = Console.ReadLine();

            DateTime birthDate;
            string sBirthDate;
            var ruCulture = new System.Globalization.CultureInfo("ru-RU");
            do
            {
                Console.WriteLine("Date of birth: ");
                sBirthDate = Console.ReadLine();
            }
            while (!DateTime.TryParse(sBirthDate, ruCulture.DateTimeFormat, System.Globalization.DateTimeStyles.None, out birthDate));

            try
            {
                UserBLL.UserBLL.AddUser(name, birthDate);
            }
            catch(Exception e)
            {
                Console.WriteLine("Input values were wrong");
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("User added");
        }
        private static void ShowNotes(IEnumerable<User> users)
        {
            foreach (var item in users)
            {
                Console.WriteLine($"{item.UserId} --- {item.Name} --- {item.Age}");
            }
        }
    }
}
