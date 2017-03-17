using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayCopy
{
    public class Person
    {
        // 创建两个属性
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // 重写Object类的ToString()方法
        public override string ToString()
        {
            return string.Format("{0} {1}", FirstName, LastName);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArray1 = { 1, 2};
            // 通过创建intArray1的浅表副本传递值给intArray2
            int[] intArray2 = (int[])intArray1.Clone();
            Console.WriteLine(intArray2.ToString());

            Person[] beatles = {
                new Person { FirstName = "John", LastName = "Lennon"},
                new Person { FirstName = "Paul", LastName = "MacCartney"}
            };
            // 通过创建beatles的浅表副本传递引用给beatlesClone,若修改
            // beatlesClone中一个元素的属性就会改变beatles中的对应对象
            Person[] beatlesClone = (Person[])beatles.Clone();
            Console.WriteLine(beatlesClone.ToString());

            Console.Read();


        }
    }
}
