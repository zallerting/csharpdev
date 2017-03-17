using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayTest
{
    public class Person
    {
        // 创建Person类的两个属性
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // 重写Object类的ToString()方法
        public override string ToString()
        {
            return string.Format("{0} {1}", FirstName,LastName) ;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // 创建使用从0开始的索引，具有指定Type类型，Length长度的一维Array
            Array intArray1 = Array.CreateInstance(typeof(int), 5);
            for (int i = 0; i < 5; i++)
            {
                // 将某值value设置给一维Array中指定位置index处的元素
                intArray1.SetValue(33,i);
            }
            for (int i = 0; i < 5; i++)
            {
                // 获取一维Array中指定位置index处的元素
                Console.WriteLine(intArray1.GetValue(i));
            }

            // CreateInstance()也可以创建多维数组和不基于0的数组
            int[] lengths = {2,3};     // 多维Array的维长
            int[] lowerBounds = {1,10};// 多维Array的索引下限 
            // 创建不从0开始的索引，具有指定Type类型，索引下限lowerBounds，维长lengths的多维Array
            Array racers = Array.CreateInstance(typeof(Person), lengths, lowerBounds);
            // 将某对象object设置给二维Array中指定索引下限lowerBound开始，指定维长lengths处
            racers.SetValue(new Person
            {
                FirstName = "Alain",
                LastName = "Prost"
            }, index1 : 1, index2 : 10);
            racers.SetValue(new Person
            {
                FirstName = "Emerson",
                LastName = "Fittipaldi"
            }, index1 : 1, index2 : 11);
            racers.SetValue(new Person
            {
                FirstName = "Ayrton",
                LastName = "Senna"
            }, index1 : 1, index2 : 12);
            racers.SetValue(new Person
            {
                FirstName = "Michael",
                LastName = "Schumacher"
            }, index1 : 2, index2 : 10);
            racers.SetValue(new Person
            {
                FirstName = "Fernando",
                LastName = "Alonso"
            }, index1 : 2, index2 : 11);
            racers.SetValue(new Person
            {
                FirstName = "Jenson",
                LastName = "Button"
            }, index1 : 2, index2 : 12);
            // 尽管数组不是基于0，但可以使用一般的C#表示法将它赋予一个变量
            // 将Array类型转换为Person[,]数组类型
            Person[,] racers2 = (Person[,])racers;
            Console.WriteLine("racers2[1,10] = " + racers2[1, 10]);
            Console.WriteLine("racers2[2,12] = " + racers2[2, 12]);

            Console.Read();
        }
    }
}
