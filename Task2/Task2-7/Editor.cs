using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_7
{
    public class Editor
    {
        private List<Figure> figures;

        public Editor()
        {
            figures = new List<Figure>();
        }
        public bool CriateLine()
        {
            Line l;
            bool res = false;
            try
            {
                l = new Line();
                figures.Add(l);
                res = true;
            }catch(Exception e)
            {
                Console.WriteLine( e.Message ); 
            }
            return res;
        }
    }
}
