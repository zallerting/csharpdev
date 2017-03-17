using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySortComparer
{
    public class Person
    {
        // 创建两个属性
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // 重写Object类的ToString方法
        public override string ToString()
        {
            return string.Format("{0} {1}", FirstName, LastName); 
        }
    }
    public enum PersonCompareType
    {
        FirstName,
        LastName
    }
    // 创建实现至IComparer<Person>泛型接口的类
    public class PersonComparer : IComparer<Person>
    {
        // 创建私有属性
        private PersonCompareType compareType;
        // 创建PersonComparer类的构造函数
        public PersonComparer(PersonCompareType compareType)
        {
            this.compareType = compareType;
        }
        // 实现派生至IComparer<Person>泛型接口的Compare方法
        public int Compare(Person x, Person y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return 1;
            if (y == null) return -1;
            // 选择按照FirstName或LastName进行排序
            switch (compareType)
            {
                case PersonCompareType.FirstName:
                    // 比较两个指定的string对象，并返回一个指示两者在排序顺序中的相对位置的整数
                    return string.Compare(x.FirstName, y.FirstName);
                case PersonCompareType.LastName:
                    return string.Compare(x.LastName, y.LastName);
                default:
                    // 传入比较对象参数出错
                    throw new ArgumentException("unexpected compare type");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // 创建Person类数组并初始化
            Person[] persons =
            {
                new Person { FirstName = "Daemon", LastName = "Hill"},
                new Person { FirstName = "Niki", LastName = "Lauda"},
                new Person { FirstName = "Ayrton", LastName = "Senna"},
                new Person { FirstName = "Graham", LastName = "Hill"}
            };
            // 按照名字进行排序
            Array.Sort(persons, new PersonComparer(PersonCompareType.FirstName));
            foreach (var person in persons)
            {
                Console.WriteLine(person);
            }
            // 按照姓氏进行排序
            Array.Sort(persons, new PersonComparer(PersonCompareType.LastName));
            foreach (var person in persons)
            {
                Console.WriteLine(person);
            }

            Console.Read();
        }
    }
}
