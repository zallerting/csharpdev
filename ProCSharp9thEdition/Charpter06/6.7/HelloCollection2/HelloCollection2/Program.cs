using System;
using System.Collections;
using System.Collections.Generic;

namespace HelloCollection2
{
    public class HelloCollection
    {
        public IEnumerator GetEnumerator()
        {
            // 实例化并返回一个新的yield类型
            return new Enumerator(0);
        }

        // yield类型当做内部类Enumerator
        public class Enumerator : IEnumerator<string>, IEnumerator, IDisposable
        {
            // state定义了迭代的当前位置
            private int state;
            // 对应state位置的对象
            private string current;

            // yield类型实现IEnumerator和IDisposable接口的属性和方法
            // Enumerator类的构造函数
            public Enumerator(int state)
            {
                this.state = state;
            }
            // 将枚举数推进到集合的下一个元素
            bool IEnumerator.MoveNext()
            {
                switch (state)
                {
                    case 0:
                        current = "Hello";
                        state = 1;
                        return true;
                    case 1:
                        current = "World";
                        state = 2;
                        return true;
                    case 2:
                        break;        
                }
                return false;
            }
            // 将枚举数设置为其初始位置，该位置位于集合中第一个位置之前
            void IEnumerator.Reset()
            {
                throw new NotSupportedException();
            }
            // 获取集合中的当前元素
            Object IEnumerator.Current
            {
                get
                {
                    return current;
                }
            }
            // 获取集合中位于枚举数当前位置的元素
            string IEnumerator<string>.Current
            {
                get
                {
                    return current;
                }
            }
            // 定义一种释放分配的资源的方法
            public void Dispose()
            {
                throw new NotImplementedException();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
