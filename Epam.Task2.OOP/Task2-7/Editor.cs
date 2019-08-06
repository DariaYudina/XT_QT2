using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_7.Graphics
{
    public class Editor
    {
        private List<Figure> figures;

        public Editor()
        {
            figures = new List<Figure>();
        }
        public bool CreateLine(double x1, double y1, double x2, double y2)
        {
            Point p1 = new Point(x1, y1);
            Point p2 = new Point(x2, y2);
            Line line = null;

            try
            {
                line = new Line(p1, p2);
            }
            catch (ArgumentException)
            {
                return false;
            }

            figures.Add(line);
            return true;
        }
        public bool CreateCircle(double x, double y, double r)
        {
            Circle circle = null;

            try
            {
                circle = new Circle(x, y, r);
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }

            figures.Add(circle);
            return true;
        }

        public bool CreateRound(double x, double y, double r)
        {
            Round round = null;

            try
            {
                round = new Round(x, y, r);
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }

            figures.Add(round);
            return true;
        }

        public bool CreateRing(double x, double y, double r, double outerR)
        {
            Ring ring = null;

            try
            {
                ring = new Ring(x, y, r, outerR);
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }

            figures.Add(ring);
            return true;
        }

        public bool CreateRectangle(double x, double y, double width, double height)
        {
            Rectangle rectangle = null;

            try
            {
                rectangle = new Rectangle(x, y, width, height);
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }

            figures.Add(rectangle);
            return true;
        }

        public void DrawAll()
        {
            foreach (Figure figure in figures)
            {
                figure.draw();
            }
        }

        public void DeleteAll()
        {
            figures.Clear();
        }
    }
}
