using DesignPatterns.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.PL
{
    public class AppMenu
    {
        public static void OpenMenu()
        {
            Console.WriteLine("Plase select some action:");
            Console.WriteLine("1. Add User");
            Console.WriteLine("2. Show Users");
            Console.WriteLine("3. Exit");

            var input = Console.ReadLine();

            if (uint.TryParse(input, out uint selectedOption)
                && selectedOption > 0
                && selectedOption < 4)
            {
                switch (selectedOption)
                {
                    case 1:
                        //NotesManager.AddNote(Console.ReadLine(), DateTime.Now);
                        //SelectOptionByUser();
                        User user = new User();
                        break;
                    case 2:
                        //ShowNotes(NotesManager.GetAllNotes());
                        //SelectOptionByUser();
                        break;
                    case 3:
                        return;
                }
            }
        }
    }
}
