using System;

namespace IOTest
{
    class Program
    {
        static void Main(string[] args)
        {
            String s = Console.ReadLine();
            Console.WriteLine(s);

            int i = 10;
            int j = 20;
            Console.WriteLine("{0} plus {1} equals {2}", i, j, i+j);

            i = 940;
            j = 73;
            Console.WriteLine("  {0, 4}\n + {1, 3}\n --------\n {2, 5}", i, j, i+j);

            decimal i2 = 940.23m;
            decimal j2 = 73.70m;
            Console.WriteLine("{0, 9:C2}\n + {1, 5:C2}\n --------\n {2, 9:C2}",i2 ,j2, i2+j2);

            double d = 0.235;
            Console.WriteLine("{0:#.00}",d);

            Console.ReadLine();
        }
    }
}
