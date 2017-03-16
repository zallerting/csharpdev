using System;

namespace GenericsStruct
{
    // 定义泛型结构Nullable<T>
    public struct Nullable<T>
        where T:struct // 约束T为结构类型
    {
        // 创建Nullable的构造函数
        public Nullable(T value)
        {
            hasValue = true;
            this.value = value;
        }
        private bool hasValue;
        public bool HasValue
        {
            get
            {
                return hasValue;
            }
        }
        private T value;
        public T Value
        {
            get
            {
                if (!hasValue)
                {
                    throw new InvalidOperationException("no value");
                }
                return value;
            }
        }
        // 显式定义操作符重载，因为将Nullable<T>类型强制转换为T类型，hasValue为false时将抛出异常
        public static explicit operator T(Nullable<T> value)
        {
            return value.Value;
        }
        // 隐式定义操作符重载，因为将T类型强制转换为Nullable<T>类型总能成功转换
        public static implicit operator Nullable<T>(T value)
        {
            return new Nullable<T>(value);
        }
        // 重写Object类的ToString方法
        public override string ToString()
        {
            if (!hasValue)
                return string.Empty;
            return value.ToString();
        }
    }
    class MainEntry
    {
        static void Main(String[] args)
        {
            Nullable<int> x1;
            // x1 = null;
            x1 = 4;
            if (x1.HasValue)
            {
                int y = x1.Value;
            }
            // "?"运算符：允许定义可空类型的变量
            int? x2;
            x2 = null;

            int? x3 = GetNullableType();
            if (x3 == null)
            {
                Console.WriteLine("x3 is null");
            }
            else if (x3 < 0)
            {
                Console.WriteLine("x is smaller than 0");
            }

            // 两个可空变量中任何一个为null时，它们的和就是null
            int? x4 = GetNullableType();
            int? x5 = GetNullableType();
            int? x6 = x4 + x5;

            // 非可空类型隐式转换为可空类型
            int y1 = 4;
            int? x7 = y1;
            // 可空类型显式转换为非可空类型
            int? x8 = GetNullableType();
            int y2 = (int)x8;
            // "??"合并运算符：为转换定义一个默认值，以防可空类型的值是null
            int? x9 = GetNullableType();
            int y3 = x9 ?? 0; // 当x9为null时，y3取值为0
            

        }

        private static int? GetNullableType()
        {
            return null;
        }
    }
}
