using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Epam.Task5.BackupSystem
{
    public class Menu
    {
        private bool exit = false;
        private FilesState userFiles;
        public void OpenMenu()
        {
            do
            {
                Console.WriteLine($"Menu:{Environment.NewLine} 1: Control directory {Environment.NewLine} 2: Backup directory to date { Environment.NewLine} 3: Exit { Environment.NewLine}Please input selected menu item:{Environment.NewLine}");
                bool success;
                int selectedMenu;
                validation(out success, out selectedMenu);
                if (success)
                {
                    switch (selectedMenu)
                    {
                        case 1: ControlDirectory(); break;
                        case 2: BackupDirectory(); break;
                        case 3: exit = true; break;
                        default: Console.WriteLine("Please input an existing menu item"); break;
                    }
                }
                else
                {
                    Console.WriteLine("Please input a number");
                }
            } while (!exit);
        }
       
        public void validation(out bool exitvalidation, out int number)
        {
            number = 0;
            exitvalidation = false;
            while (!exitvalidation)
            {
                Console.WriteLine("Enter a number:\n");
                string value = Console.ReadLine();
                if (Int32.TryParse(value, out number))
                {
                    exitvalidation = true;
                }
            }
            FileSystemWatcher watcher = new FileSystemWatcher();
        }
        public void ControlDirectory()
        {
            Console.WriteLine("Please input full path to directory with your files: ");
            //For eximple: "e:\repozitory"
            string pathToCatalog = Console.ReadLine();
            try
            {
                userFiles = new FilesState(@pathToCatalog);
                Thread.Sleep(1500);
                Console.Clear();
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine("DirectoryNotFound: " + e.Message);
            }
        }
        public void BackupDirectory()
        {
          
            if (userFiles != null)
            {
                userFiles.Stop();
                Console.WriteLine("дата");
                string date = Console.ReadLine();
                userFiles.BackupFiles(date);
                Console.WriteLine("Backup");
            }
            else
            {
                Console.WriteLine("You didn't select folder with files and with change history");
            }
        }
       
    }
}
