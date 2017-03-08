using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringExample
{
    class StringTest
    {
        static int Main(string[] args)
        {
            String str1 = "a string";
            String str2 = str1;
            String filepath = @"D:\GitHub\csharpdev\ProCSharp9thEdition
\Charpter02\2.4\StringExample";
            Console.WriteLine("str1 is " + str1);
            Console.WriteLine("str2 is " + str2);
            str1 = "another string";
            Console.WriteLine("str1 is " + str1);
            Console.WriteLine("str2 is " + str2);
            Console.WriteLine("filepath is " + filepath);
            Console.ReadLine();
            return 0;
        }
    }
}
