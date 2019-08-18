using Epam.TreeLayerArchitecture.Entities;
using Epam.TreeLayerArchitecture.UserBLL;
using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

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
                                     $"3. Add awards {Environment.NewLine}" +
                                     $"4. Show all users{Environment.NewLine}" +
                                     $"5. Show all awards{Environment.NewLine}" +
                                     $"6. Delete user{Environment.NewLine}" +
                                     $"7. Delete award{Environment.NewLine}" +
                                     $"8. Exit{Environment.NewLine}" +
                                     "");
                var input = Console.ReadLine();
                if (int.TryParse(input, out int selectedOption)
                    && selectedOption > 0
                    && selectedOption < 9)
                {
                    switch (selectedOption)
                    {
                        case 1:
                            AddUser();
                            break;
                        case 2:
                            AddAwardToUser();
                            break;
                        case 3:
                            AddAward();
                            break;
                        case 4:
                            ShowAllUsers();
                            break;
                        case 5:
                            ShowAllAwards();
                            break;
                        case 6:
                            DeleteUser();
                            break;
                        case 7:
                            DeleteAward();
                            break;
                        case 8:
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
        #region work with UserBLL

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
                UserBLL.UserBLL.AddUser(name, birthDate);  
            }
            catch(ArgumentException e)
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
            int index = 1;
            foreach (var item in users)
            {
                Console.WriteLine($"\t{index}: {item.Name} --- {item.Age}");
                ShowAwardsOfUser(item);
                index++;
            }
        }
        private static void ShowAwardsOfUser(User user)
        {
            if ( user.Awards.Any() )
            {
                Console.WriteLine("\t\tUser awards:");
                int index = 1;
                foreach (var item in user.Awards)
                {
                    Console.WriteLine($"\t\t\t{index}: {item.Title}");
                    index++;
                }
            }
        }
        private static void DeleteUser()
        {
            Console.WriteLine("Select user to delete:");
            ShowAllUsers();
            var input = Console.ReadLine();
            if (int.TryParse(input, out int res))
            {
                var users = UserBLL.UserBLL.GetAllUsers().ToArray();
                User selectUser = users[res - 1];
                if (UserBLL.UserBLL.DeleteUser(selectUser))
                {
                    Console.WriteLine("User deleted");
                }
                else
                {
                    Console.WriteLine("User Didn't delete");
                }
            }
            else
            {
                Console.WriteLine("Input value were wrong");
            }
        }
        private static void AddAwardToUser()
        {
            Console.WriteLine("Select user to award:");
            ShowAllUsers();
            var input = Console.ReadLine();
            if (int.TryParse(input, out int res))
            {
                var users = UserBLL.UserBLL.GetAllUsers().ToArray();
                User selectUser = users[res - 1];
                AwardUser(selectUser);
            }
            else
            {
                Console.WriteLine("Input value were wrong");
            }
        }
        private static void AwardUser(User user)
        {
            Console.WriteLine("Select award to add:");
            ShowAllAwards();
            var input = Console.ReadLine();
            if (int.TryParse(input, out int res))
            {
                var awards = AwardBLL.GetAllAwards().ToArray();
                Award selectedAward = awards[res - 1];
                if (UserBLL.UserBLL.AddAward(user.UserId, selectedAward))
                {
                    Console.WriteLine("User award added");
                }
                else
                {
                    Console.WriteLine("User award didn't add");
                }
            }
            else
            {
                Console.WriteLine("Input value were wrong");
            }
        }
        #endregion

        #region work with AwardBLL

        private static void ShowAllAwards()
        {
            var awards = AwardBLL.GetAllAwards();
            int i = 1;
            foreach (var item in awards)
            {
                Console.WriteLine($"\t{i}: {item.Title}");
                i++;
            }
        }
        public static void AddAward()
        {
            Console.WriteLine("Input award title");
            string title = Console.ReadLine();
            try
            {
                AwardBLL.AddAward(title);
                Console.WriteLine("Award added");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Input values were wrong");
                Console.WriteLine(e.Message);
            }         
        }
        private static void DeleteAward()
        {
            Console.WriteLine("Select award to delete:");
            ShowAllAwards();
            var input = Console.ReadLine();
            if (int.TryParse(input, out int res))
            {
                var awards = AwardBLL.GetAllAwards().ToArray();
                Award selectAward = awards[res - 1];
                if (AwardBLL.DeleteAward(selectAward))
                {
                    Console.WriteLine("Award deleted");
                }
                else
                {
                    Console.WriteLine("Award Didn't delete");
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
