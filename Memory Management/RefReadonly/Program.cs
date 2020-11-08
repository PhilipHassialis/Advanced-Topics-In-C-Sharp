using System;

namespace RefReadonly
{

    struct Point
    {
        public double X, Y;

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        private static Point origin = new Point();
        public static ref readonly Point Origin => ref origin;

        public void Reset()
        {
            X = Y = 0;
        }

        public override string ToString()
        {
            return $"({X},{Y})";
        }
    }

    class Program
    {
        void changeMe(ref Point p)
        {
            p.X++;
        }

        double MeasureDistance(in Point p1, in Point p2)
        {
            p1.Reset(); // compiles but does nothing - in parameters are immutable
            var dx = p1.X - p2.X;
            var dy = p1.Y - p2.Y;
            //changeMe(ref p1); cannot work -> mutating to a ref from an in var is forbidden
            return Math.Sqrt(dx * dx + dy * dy);
        }

        double MeasureDistance(Point p1, Point p2)
        {
            return 0.0;
        }


        public Program()
        {
            var p1 = new Point(1, 1);
            var p2 = new Point(4, 5);

            var distance = MeasureDistance(in p1, in p2);
            Console.WriteLine($"Distance between {p1} and {p2} is {distance}");
            var distance2 = MeasureDistance(p1, p2);
            Console.WriteLine($"And here's a nice zero: {distance2}");
            var distanceFromOrigin = MeasureDistance(p1, Point.Origin);

            Point copyOfOrigin = Point.Origin; // by value copy
            //ref var massWithOrigin = ref Point.Origin; // doesn't work because its readonly

            ref readonly var originRef = ref Point.Origin; // works because we assign it to a readonly var
            //originRef.X++; // of course this doesn't work
        }

        static void Main(string[] args)
        {
            new Program();
        }
    }
}
