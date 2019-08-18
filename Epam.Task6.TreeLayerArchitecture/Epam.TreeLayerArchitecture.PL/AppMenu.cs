using Epam.TreeLayerArchitecture.Entities;
using Epam.TreeLayerArchitecture.UserBLL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                                     $"2. Add awards to user{Environment.NewLine}" +
                                     $"3. Show all users{Environment.NewLine}" +
                                     $"4. Show all awards{Environment.NewLine}" +
                                     $"5. Delete user{Environment.NewLine}" +
                                     $"6. Delete award{Environment.NewLine}" +
                                     $"7. Exit{Environment.NewLine}" +
                                     "");
                var input = Console.ReadLine();
                if (int.TryParse(input, out int selectedOption)
                    && selectedOption > 0
                    && selectedOption < 5)
                {
                    switch (selectedOption)
                    {
                        case 1:
                            AddUser();
                            break;
                        case 2:
                            //ShowAllUsers();
                            break;
                        case 3:
                            ShowAllUsers();
                            break;
                        case 4:
                            //DeleteUser();
                            break;
                        case 5:
                            DeleteUser();
                            break;
                        case 6:
                            //DeleteUser();
                            break;
                        case 7:
                            exit = true;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Input correct menu item");
                }
            } while (!exit);
        }
        #region work with BLL

        private void AddUser()
        {
            Console.WriteLine("Please Input name:");
            string name = Console.ReadLine();
            if (!IsValidString(name))
            {
                Console.WriteLine("Input name were wrong");
                return;
            }
            DateTime birthDate;
            string sBirthDate;
            do
            {
                var temp = DateTime.Now.ToShortDateString().ToString(CultureInfo.CurrentCulture);
                Console.WriteLine($"{Environment.NewLine}Please specify a date of birth. Format: " + temp);
                sBirthDate = Console.ReadLine();
            }
            while (!DateTime.TryParse(sBirthDate, CultureInfo.CurrentCulture, DateTimeStyles.None, out birthDate));

            try
            {
                UserBLL.UserBLL.AddUser(name, birthDate);  //to BLL;
            }
            catch(Exception e)
            {
                Console.WriteLine("Input values were wrong");
                Console.WriteLine(e.Message);
                return;
            }
            Console.WriteLine("User added");
        }
        private static void ShowAllUsers()
        {
            var users = UserBLL.UserBLL.GetAllUsers();
            int i = 1;
            foreach (var item in users)
            {
                Console.WriteLine($"\t{i}: {item.Name} --- {item.Age}");
                i++;
            }
        }
        private static void DeleteUser()
        {
            Console.WriteLine("Select user to delete:");
            ShowAllUsers();
            var input = Console.ReadLine();
            int res;
            if (int.TryParse(input, out res))
            {               
                var users = UserBLL.UserBLL.GetAllUsers().ToArray();
                User selectUser = users[res - 1];
                if (UserBLL.UserBLL.DeleteUser(selectUser))
                {
                    Console.WriteLine("User deleted");
                }
                else
                {
                    Console.WriteLine("User not deleted");
                }
            }
            else
            {
                Console.WriteLine("Input value were wrong");
            }

        }

        #endregion
        public static bool IsValidString(string value)
        {
            string pattern = @"^[a-zA-Zа-яА-Я]{1,25}$";
            return Regex.IsMatch(value, pattern);
        }
    }
}
