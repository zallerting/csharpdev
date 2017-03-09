using System;

namespace StructTest
{
    struct Dimensions
    {
        public double Length;
        public double Width;
        public Dimensions(double length, double width)
        {
            Length = length;
            Width = width;
        }
        public double Diagonal
        {
            get
            {
                return Math.Sqrt(Length * Length + Width * Width);
            }
        }
        static void Main(string[] args)
        {
            Dimensions dimensions = new Dimensions(6.6, 7.7);
            Console.WriteLine("Diagonal is " + dimensions.Diagonal);
            Console.Read();
        }
    }
}
