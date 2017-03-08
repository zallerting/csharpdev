using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumTest
{
    // 创建枚举
    public enum TimeOfDay
    {
        Morning = 0,
        Afternoon = 1,
        Evening = 2
    }
    class Program
    {
        // 创建静态方法
        static void WriteGreeting(TimeOfDay timeOfDay)
        {
            switch (timeOfDay)
            {
                case TimeOfDay.Morning:
                    Console.WriteLine("Good morning!");
                    break;
                case TimeOfDay.Afternoon:
                    Console.WriteLine("Good afternoon!");
                    break;
                case TimeOfDay.Evening:
                    Console.WriteLine("Good evening!");
                    break;
                default:
                    Console.WriteLine("Hello!");
                    break;
            }
        }
        public static void Main(string[] args)
        {
            WriteGreeting(TimeOfDay.Morning);
            WriteGreeting(TimeOfDay.Afternoon);
            WriteGreeting(TimeOfDay.Evening);
            // 枚举已成为基本类型
            TimeOfDay time = TimeOfDay.Evening;
            Console.WriteLine(time.ToString());
            // 
            TimeOfDay time2 = (TimeOfDay)Enum.Parse(typeof(TimeOfDay), "evening", true);
            Console.WriteLine((int)time2);
            Console.ReadLine();
        }
    }
}
