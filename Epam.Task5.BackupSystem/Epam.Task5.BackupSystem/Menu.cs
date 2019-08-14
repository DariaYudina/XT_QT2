using System;
using System.Globalization;
using System.IO;
using System.Threading;

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
                Console.WriteLine($"Menu:{Environment.NewLine} 1: Control directory {Environment.NewLine} 2: Backup directory to date { Environment.NewLine} 3: Exit { Environment.NewLine}Please press 'y','n' or 'e' key accordingly:{Environment.NewLine}");

                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.Y: ControlDirectory(); break;
                        case ConsoleKey.N: BackupDirectory(); break;
                        case ConsoleKey.E: exit = true; break;
                        default: Console.WriteLine($"{Environment.NewLine}Please input an existing menu item"); break;
                    }
                
            } while (!exit);
        }
        public void ControlDirectory()
        {
            Console.WriteLine($"{Environment.NewLine}Please input full path to directory with your files: ");
            //For eximple: "e:\repozitory"
            string pathToCatalog = Console.ReadLine();
            try
            {
                FileSystemWatcher watcher = new FileSystemWatcher();
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

                var temp = DateTime.Now.ToString(CultureInfo.CurrentCulture);
                Console.WriteLine ($"{Environment.NewLine}Please specify a date. Format: " + temp);
                try
                {
                    userFiles.BackupFiles(Console.ReadLine());
                    Console.WriteLine("Backup done");
                }
                catch(InvalidCastException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine($"{Environment.NewLine}You didn't select folder with files and with change history");
            }
        }

    }
}
