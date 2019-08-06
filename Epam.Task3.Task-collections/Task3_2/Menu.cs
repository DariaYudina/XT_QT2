using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.Task3_3and4.Task_collections
{
    class Menu
    {
        private bool exit = false;
        private WordsFrequency text;
        public void openMenu()
        {
            do
            {
                Console.WriteLine("Menu:\n");
                Console.WriteLine("1: Word frequency method" + Environment.NewLine +
                                  "2: Exit" + Environment.NewLine);
                Console.WriteLine("Please input selected menu item:\n");
                string value = Console.ReadLine();
                int selectedMenu;
                bool success = Int32.TryParse(value, out selectedMenu);

                if (success)
                {
                    switch (selectedMenu)
                    {
                        case 1: useWordFrequency(); break;
                        case 2: exit = true; break;
                        default: Console.WriteLine("Please input an existing menu item"); break;
                    }
                }
                else { Console.WriteLine("Please input a number"); }
            } while (!exit);
        }
        public void useWordFrequency()
        {
            Console.WriteLine("Please input text");
            text = new WordsFrequency(Console.ReadLine());
            Console.WriteLine("Word Frequency: " );
            text.printWordsFrequency();
            Console.WriteLine("Total words: " + text.GetCountOfWords());            
        }
        
    }
}
