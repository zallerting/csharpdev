using System;

namespace Scope2
{
    class ScopeTest2
    {
        static int i = 20;
        public static void Main(string[] args)
        {
            int i = 30;
            Console.WriteLine("i = " + i);
            Console.WriteLine("ScopeTest2.i = " + ScopeTest2.i);
            Console.ReadLine();
            return;
        }
    }
}
