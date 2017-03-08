using System;

namespace VarType
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = "Bugs Bunny";
            var age = 25;
            var isRabbit = true;

            Type nameType = name.GetType();
            Type ageType = age.GetType();
            Type isRabbitType = isRabbit.GetType();

            Console.WriteLine("name type is " + nameType.ToString());
            Console.WriteLine("age type is " + ageType);
            Console.WriteLine("isRabbit type is " + isRabbitType);
            Console.ReadLine();
        }
    }
}
