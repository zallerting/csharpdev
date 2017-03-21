using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverload
{
    struct Vector
    {
        public double x, y, z;
        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        // 通过提供一个复制其值的Vector，来指定矢量的初始值
        public Vector(Vector rhs) // Vecotr rhs通常被称为复制构造函数
        {
            x = rhs.x;
            y = rhs.y;
            z = rhs.z;
        }
        public override string ToString()
        {
            return "( " + x + ", " + y + "," + z + " )"; 
        }
        // 为"+"运算符提供支持的运算符重载
        public static Vector operator + (Vector lhs, Vector rhs)
        {
            Vector result = new Vector(lhs);
            result.x += rhs.x;
            result.y += rhs.y;
            result.z += rhs.z;
            return result;
        }
        // 为"*"运算符提供支持的运算符重载
        public static Vector operator * (double lhs, Vector rhs)
        {
            return new Vector(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z);
        }
        public static Vector operator *(Vector lhs, double rhs)
        {
            // return new Vector(rhs * lhs.x, rhs * lhs.y, rhs * lhs.z);
            // 下面实现相同功能，重用上面相乘操作的代码
            return rhs * lhs;
        }
        // 计算矢量的内积
        public static double operator * (Vector lhs, Vector rhs)
        {
            return lhs.x * rhs.x + lhs.y * rhs.y + lhs.z * rhs.z;
        }
        // 为"=="运算符提供支持的运算符重载
        public static bool operator == (Vector lhs, Vector rhs)
        {
            if (lhs.x == rhs.x && lhs.y == rhs.y && lhs.z == rhs.z)
                return true;
            else
                return false;
        }
        // 重载比较运算符，需要成对重载(== !=; > <; >= <=)
        // 重载比较运算符同时需要重载Object.Equals(object o)及Object.GetHashCode()
        public static bool operator != (Vector lhs, Vector rhs)
        {
            return !(lhs == rhs);
        }


        // 主方法，程序的入口
        static void Main(String[] args)
        {
            Vector vect1, vect2, vect3;
            vect1 = new Vector(3.0, 3.0, -10.0);
            vect2 = new Vector(3.0, 3.0, -10.0);
            vect3 = vect1 + vect2;
            Console.WriteLine("vect1 = " + vect1.ToString());
            Console.WriteLine("vect2 = " + vect2.ToString());
            Console.WriteLine("vect3 = vect1 + vect2 = " + vect3.ToString());
            Console.WriteLine("2 * vect3 = " + 2 * vect3);
            vect3 += vect2;
            Console.WriteLine("vect3 += vect2 gives " + vect3);
            vect3 = vect1 * 2;
            Console.WriteLine("vect3 *= vect2 gives " + vect3);
            double dot = vect1 * vect3;
            Console.WriteLine("dot = vect1 * vect3 = " + dot);
            Console.WriteLine("vect1 == vect2 returns " + (vect1 == vect2));
            Console.WriteLine("vect1 == vect3 returns " + (vect1 == vect3));
            Console.WriteLine("vect2 == vect3 returns " + (vect2 == vect3));
            Console.WriteLine("vect1 != vect2 returns " + (vect1 != vect2));
            Console.WriteLine("vect1 != vect3 returns " + (vect1 != vect3));
            Console.WriteLine("vect2 != vect3 returns " + (vect2 != vect3));

            Console.Read();
        }
    }
}
