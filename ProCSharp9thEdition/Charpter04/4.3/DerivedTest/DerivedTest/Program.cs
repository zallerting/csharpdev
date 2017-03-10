using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerivedTest
{
    class BaseClass
    {
        // 创建基类虚函数
        public virtual string VirtualMethod()
        {
            return "This method is virtual and defined in BaseClass.";
        }
    }
    class DerivedClass : BaseClass
    {
        // 重写基类虚函数
        public override string VirtualMethod()
        {
            return "This method is an override defined in DerivedClass.";
        }
        static void Main(string[] args)
        {
            Console.WriteLine(new BaseClass().VirtualMethod());
            Console.Read();
        }
    }
}
