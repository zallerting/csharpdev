using System;
using System.Drawing;

namespace StaticConstructor
{
    class UserPreference
    {
        // 创建只读字段，只能在静态构造器中设置
        public static readonly Color BackColor;
        // 创建静态构造函数,加载类时总是由.NET运行库调用它
        static UserPreference()
        {
            DateTime now = DateTime.Now;
            if (now.DayOfWeek == DayOfWeek.Saturday
                || now.DayOfWeek == DayOfWeek.Sunday)
            {
                BackColor = Color.Green;
            }
            else
            {
                BackColor = Color.Red;
            }
        }
    }

    class MainEntryPoint
    {
        static void Main(string[] args)
        {
            Console.WriteLine("BackColor is:" + UserPreference.BackColor.ToString());
            Console.ReadLine();
        }
    }
}
