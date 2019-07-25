using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_7.Graphics
{
    class EditorMenu
    {
        private int cursor;
        private int selectedMenuItem = -1;
        private bool exit;
        private Editor editor = new Editor();
        public void DrawMenu()
        {
            exit = false;
            do
            {
                Console.WriteLine("Please input munu item");
                selectedMenuItem = Convert.ToInt32(Console.ReadLine());
                switch (selectedMenuItem)
                {
                    case 0:
                        menuItemCreateLine();
                        break;
                    case 1:
                        menuItemCreateCircle();
                        break;
                    case 2:
                        menuItemCreateRound();
                        break;
                    case 3:
                        menuItemCreateRing();
                        break;
                    case 4:
                        menuItemCreateRectangle();
                        break;
                    case 5:
                        menuItemDrawAll();
                        break;
                    case 6:
                        menuItemDeleteAll();
                        break;
                    default:
                        break;
                }
                selectedMenuItem = -1;
            }
            while
                (!exit);
        }

        private void menuItemDeleteAll()
        {
            Console.WriteLine("Deleting all shapes...");
            editor.DeleteAll();
            Console.WriteLine("All shapes deleted");
        }

        private void menuItemCreateCircle()
        {
            Console.WriteLine("Please input circle parameters\n");
            Console.WriteLine("Input x coordinate of circle center\n");
            double x;
            double.TryParse(Console.ReadLine(), out x);
            Console.WriteLine("Input y coordinate of circle center\n");
            double y;
            double.TryParse(Console.ReadLine(), out y);
            Console.WriteLine("Input radius\n");
            double r;
            double.TryParse(Console.ReadLine(), out r);
            if (editor.CreateCircle(x, y, r))
            {
                Console.WriteLine("Circle created");
            }
            else
            {
                Console.WriteLine("An error occurs during circle creating");
            }
        }
        private void menuItemCreateRound()
        {
            Console.WriteLine("Please input round parameters\n");
            Console.WriteLine("Input x coordinate of round center\n");
            double x;
            double.TryParse(Console.ReadLine(), out x);
            Console.WriteLine("Input y coordinate of round center\n");
            double y;
            double.TryParse(Console.ReadLine(), out y);
            Console.WriteLine("Input radius\n");
            double r;
            double.TryParse(Console.ReadLine(), out r);

            if (editor.CreateRound(x, y, r))
            {
                Console.WriteLine("Round created");
            }
            else
            {
                Console.WriteLine("An error occurs during round creating");
            }
        }
        private void menuItemCreateRing()
        {
            Console.WriteLine("Please input ring parameters\n");
            Console.WriteLine("Input x coordinate of ring center\n");
            double x;
            double.TryParse(Console.ReadLine(), out x);
            Console.WriteLine("Input y coordinate of ring center\n");
            double y;
            double.TryParse(Console.ReadLine(), out y);
            Console.WriteLine("Input inner radius\n");
            double innerR;
            double.TryParse(Console.ReadLine(), out innerR);
            Console.WriteLine("Input outer radius\n");
            double r;
            double.TryParse(Console.ReadLine(), out r);

            if (editor.CreateRing(x, y, r, innerR))
            {
                Console.WriteLine("Ring created");
            }
            else
            {
                Console.WriteLine("An error occurs during ring creating");
            }
        }
        private void menuItemCreateRectangle()
        {
            Console.WriteLine("Please input rectangle parameters\n");
            Console.WriteLine("Input x coordinate of left top vertex\n");
            double x;
            double.TryParse(Console.ReadLine(), out x);
            Console.WriteLine("Input y coordinate of left top vertex\n");
            double y;
            double.TryParse(Console.ReadLine(), out y);
            Console.WriteLine("Input rectangle width\n");
            double width;
            double.TryParse(Console.ReadLine(), out width);
            Console.WriteLine("Input rectangle height\n");
            double height;
            double.TryParse(Console.ReadLine(), out height);

            if (editor.CreateRectangle(x, y, width, height))
            {
                Console.WriteLine("Rectangle created");
            }
            else
            {
                Console.WriteLine("An error occurs during rectangle creating");
            }
        }
        private void menuItemDrawAll()
        {
            Console.WriteLine("Drawing all shapes");
            editor.DrawAll();
        }
        private void menuItemCreateLine()
        {
            Console.WriteLine("Please input line parameters\n");
            Console.WriteLine("Input x coordinate of first point\n");
            double x1;
            double.TryParse(Console.ReadLine(),out x1);
            Console.WriteLine("Input y coordinate of first point\n");
            double y1;
            double.TryParse(Console.ReadLine(), out y1);
            Console.WriteLine("Input x coordinate of second point\n");
            double x2;
            double.TryParse(Console.ReadLine(), out x2);
            Console.WriteLine("Input y coordinate of second point\n");
            double y2;
            double.TryParse(Console.ReadLine(), out y2);
            if (editor.CreateLine(x1, y1, x2, y2))
            {
                Console.WriteLine("Line created");
            }
            else
            {
                Console.WriteLine("An error occurs during line creating");
            }
        }
    }
}
