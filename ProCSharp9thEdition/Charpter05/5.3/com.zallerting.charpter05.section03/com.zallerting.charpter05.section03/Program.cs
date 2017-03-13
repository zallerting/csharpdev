using System;

namespace com.zallerting.charpter05.section03
{
    public abstract class Calc<T>
    {
        // 抽象泛型类的抽象方法
        public abstract T Add(T x, T y);
        public abstract T Sub(T x, T y);
        // 抽象泛型类的静态成员
        public static int x;
    }
    public class IntCalc<T> : Calc<int> // 实现泛型基类时，需要在派生类中指定具体实现类型
    {
        // 实现抽象泛型类的抽象方法
        public override int Add(int x, int y)
        {
            return x + y;
        }

        public override int Sub(int x, int y)
        {
            return x - y;
        }
    }
    class MainEntryPoint
    {
        static void Main(String[] args)
        {
            // 泛型类的静态成员只能在类的一个实例中共享，所以下面存在两组静态字段
            Calc<string>.x = 5;
            Calc<int>.x = 4;
            Console.WriteLine("Calc<string>.x = " + Calc<string>.x);
            Console.WriteLine("Calc<int>.x = " + Calc<int>.x);
            Console.Read();
        }
        
    }
}
