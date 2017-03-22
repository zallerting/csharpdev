using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSorter
{
    class BubbleSorter
    {
        // 创建Sort<T>泛型方法，这个方法从Func<T1, T2, TResult>委托中引用
        static public void Sort<T>(IList<T> sortArray, Func<T, T, bool> comparison)
        {
            bool swapped = true;
            do
            {
                swapped = false;
                for (int i = 0; i < sortArray.Count - 1; i++)
                {
                    if (comparison(sortArray[i + 1], sortArray[i]))
                    {
                        T tmp = sortArray[i + 1];
                        sortArray[i + 1] = sortArray[i];
                        sortArray[i] = tmp;
                        swapped = true;
                    }
                }
            } while (swapped);
        }
    }

    class Employee
    {
        // 创建Name及Salary属性
        public string Name { get; private set;}
        public decimal Salary { get; private set; }
        // 创建Employee构造函数
        public Employee(string name, decimal salary)
        {
            this.Name = name;
            this.Salary = salary;
        }
        // 重写Object类的ToString()方法
        public override string ToString()
        {
            return string.Format("{0}, {1:C}", Name, Salary);
        }
        // 创建比较Employee对象的Salary大小的方法
        // 为了匹配Func<T, T, bool>委托的签名从而定义CompareSalary()方法
        public static bool CompareSalary(Employee e1, Employee e2)
        {
            return e1.Salary < e2.Salary;
        }
    }

    class MainEntryPoint
    {
        static void Main(String[] args)
        {
            Employee[] employees =
            {
                new Employee("Bugs Bunny", 20000),
                new Employee("Elmer Fudd", 10000),
                new Employee("Daffy Buck", 25000),
                new Employee("Wile Coyote", 1000000.38m),
                new Employee("Foghorn Leghorn", 23000),
                new Employee("RoadRunner", 50000)
            };
            BubbleSorter.Sort(employees, Employee.CompareSalary);
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
            Console.Read();
        }
    }
}
