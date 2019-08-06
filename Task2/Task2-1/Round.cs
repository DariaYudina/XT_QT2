using System;
namespace Task2_1
{
    class Round : RoundFigure
    {
        public Round (double x, double y, double radius) : base(x, y, radius) { }

        public override double X
        {
            get { return _x; }
            set{ _x = value; }
        }
        public override double Y
        {
            get { return _y; }
            set { _y = value; }
        }
        public override double GetArea
        { get { return Math.PI * Math.Pow(_radius, 2); } }

        public override double GetLength
        { get { return 2 * Math.PI * _radius; } }

        public override string ToString()
        {
            return $"Coordinates of the circle's center:( {_x}, {_y})" + Environment.NewLine + $"Radius: {_radius}";
        }
       
    }
}
