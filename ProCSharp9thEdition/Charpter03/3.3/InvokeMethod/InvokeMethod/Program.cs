using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvokeMethod
{
    class MainEntryPoint
    {
        static void Main(string[] args)
        {   
            // Try calling some static functions.         
            Console.WriteLine("PI is " + MathTest.GetPi());
            // Instantiate a MathTest object
            // This is C#'s way of instantiating a reference type
            MathTest mainTest = new MathTest();
            // Call nonstatic methods
            mainTest.value = 30;
            Console.WriteLine("Square is " + mainTest.GetSquare());
            Console.WriteLine("Square is " + mainTest.GetSquareOf(50));
            Console.ReadLine();
        }
    }
    // Define a class named MathTest on which we will call a method
    class MathTest
    {
        public int value;
        public int GetSquare()
        {
            return value * value;
        }
        public int GetSquareOf(int x)
        {
            return x * x;
        }
        public static double GetPi()
        {
            return 3.1415926;
        }
    }
}
