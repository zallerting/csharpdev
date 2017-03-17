using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySort
{
    public class Person:IComparable<Person>
    {
        // 创建两个属性
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // 实现IComparable<Person>泛型接口的CompareTo方法
        public int CompareTo(Person other)
        {
            if (other == null) return 1;
            // string类的Compare方法：比较两个指定的string对象，
            // 并返回一个指示两者在排序顺序中的相对位置的整数，
            // 比较对象相等：返回0；
            // 该实例应排在参数对象前面：返回小于0；
            // 该实例应排在参数对象后面：返回大于0；
            // 先比较LastName，若LastName相等则再比较FirstName
            int result = string.Compare(this.LastName, other.LastName);
            if (result == 0)
            {
                result = string.Compare(this.FirstName, other.FirstName);
            }
            // 返回值：大于0、等于0、小于0
            return result;
        }

        // 重写Object类的ToString方法
        public override string ToString()
        {
            return string.Format("{0} {1}", FirstName, LastName);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] names =
            {
                "Cristina Aguilera",
                "Shakira",
                "Beyonce",
                "Lady Gaga"
            };
            // 使用Array中的元素实现IComparable接口，对整个Array中的元素进行排序
            Array.Sort(names);
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            // 创建Person类数组
            Person[] persons =
            {
                new Person { FirstName = "Daemon", LastName = "Hill"},
                new Person { FirstName = "Niki", LastName = "Lauda"},
                new Person { FirstName = "Ayrton", LastName = "Senna"},
                new Person { FirstName = "Graham", LastName = "Hill"}
            };
            // 按照姓氏对Person对象对应的数组排序
            Array.Sort(persons);
            foreach(var person in persons)
            {
                Console.WriteLine(person);
            }

            Console.Read();

        }

    }
}
