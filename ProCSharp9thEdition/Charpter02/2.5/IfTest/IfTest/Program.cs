using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfTest
{
    class IfTest
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type in some characters:");
            String input = Console.ReadLine();
            if (input == "")
            {
                Console.WriteLine("You haven't typed any characters.");
            }
            else if (input.Length < 5)
            {
                Console.WriteLine("You typed less than 5 characters.");
            }
            else if (input.Length < 10)
            {
                Console.WriteLine("You typed at least 5 but less than 10 characters.");
            }
            Console.WriteLine("You typed characters are " + input.ToString());
            Console.ReadLine();
            return;
        }
    }
}
