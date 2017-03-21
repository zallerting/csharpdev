using System;

namespace TypeConvert
{
    struct ItemDetails
    {
        public string Description;
        public int ApproxPrice;
    }
    class Program
    {
        static void Main(string[] args)
        {
            // 隐式转换
            byte value1 = 10;
            byte value2 = 23;
            byte total1;
            // total1 = value1 + value2; // byte与byte的和为int，将出现编译错误
            // Console.WriteLine("total1 = " + total1);

            // 显式转换
            long val = 3000000000;
            int i = (int)val; // 无效转换，最大int值为2147483647
            Console.WriteLine("i = " + i);

            // checked运算符：测试操作是否会导致算术溢出
            long val2 = 3000000000;
            // int i2 = checked((int)val2); 
            // Console.WriteLine("i2 = " + i2);

            // 无符号数转换为char
            ushort c = 43;
            char symbol = (char)c;
            Console.WriteLine("symbol = " + symbol);

            // double类型元素转换为类型为int的结构成员变量
            double[] Prices = {25.30, 26.20, 27.40, 30.00};
            ItemDetails id;
            id.Description = "Hello there";
            id.ApproxPrice = (int)(Prices[0] + 0.5);
            Console.WriteLine("id.ApproxPrice = " + id.ApproxPrice);

            // 可空类型强制转换为非可空类型，将抛出异常
            int? aa = null;
            // int bb = (int)aa;
            // Console.WriteLine("bb = " + bb);

            // 分析一个字符串，以检索一个数字或布尔值
            string str = "100";
            int ii = int.Parse(str); // 将数字的字符串表示形式转换为它的等效32位有符号整数
            Console.WriteLine("ii = " + ii);

            Console.Read();
        }
    }
}
