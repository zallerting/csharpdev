using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysReference
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string ToString()
        {
            return string.Format("FirstName:{0}, LastName:{1}", FirstName, LastName);
        }
        static void Main(String[] args)
        {
            // 创建并初始化引用类型数组的3种不同方式
            // 数组元素是引用类型，就必须为每个元素分
            // 配内存，否则将抛出NullReferenceException类型异常
            Person[] persons1 = new Person[2];
            persons1[0] = new Person { FirstName = "Ayrton", LastName = "Senna" };
            persons1[1] = new Person { FirstName = "Michael", LastName = "Schumacher" };

            Person[] persons2 = new Person[2]
            {
                new Person { FirstName = "Ayrton", LastName = "Senna"},
                new Person { FirstName = "Michael", LastName = "Schumacher" }
            };

            Person[] persons =
            {
                new Person { FirstName = "Ayrton", LastName = "Senna"},
                new Person { FirstName = "Michael", LastName = "Schumacher" }
            };
         }
    }
}
