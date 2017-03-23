using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosureDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int someVal = 5;
            Func<int, int> f = x => x + someVal;
            someVal = 7;
            // 调用f()时使用最新someVal的值
            Console.WriteLine("f(3) = {0}", f(3));

            Console.Read();
        }
    }
}
