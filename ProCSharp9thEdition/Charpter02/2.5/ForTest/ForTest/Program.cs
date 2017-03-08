using System;

namespace ForTest
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 100; i += 10)
            {
                for (int j = i; j < i + 10; j++)
                {
                    // 判断j是否为两位数
                    if (j < 10)
                    {
                        Console.Write(" 0" + j);
                    }
                    else
                    {
                        Console.Write(" " + j);
                    }
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
