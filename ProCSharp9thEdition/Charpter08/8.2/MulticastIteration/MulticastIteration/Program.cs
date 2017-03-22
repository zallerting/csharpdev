using System;

namespace MulticastIteration
{
    // 创建一个没有参数且返回void的简单委托
    delegate void Action();
    class Program
    {
        static void One()
        {
            Console.WriteLine("ONE");
            throw new Exception("Error in One");
        }
        static void Two()
        {
            Console.WriteLine("TWO");
        }
        static void Main(String[] args)
        {
            // 多播委托:依次将One()方法的地址及Two()方法的地址添加到dl委托中
            Action dl = One;
            dl += Two;
            try
            {
                // 调用dl委托，第一个方法抛出异常后迭代停止
                dl();
            }
            catch (Exception)
            {

                Console.WriteLine("Exception caught");
            }

            // 按照调用顺序返回此多路广播委托的调用列表
            Delegate[] delegates = dl.GetInvocationList();
            foreach(Action d in delegates)
            {

                try
                {
                    d();
                }
                catch (Exception)
                {

                    Console.WriteLine("Exception caught");
                }
            }

            Console.Read();
        }
    }
}
