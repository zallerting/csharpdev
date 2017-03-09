using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorInitializer
{
    class Car
    {
        private string description;
        private uint nWheels;
        public Car(string description, uint nWheels)
        {
            this.description = description;
            this.nWheels = nWheels;
        }
        // 构造函数初始化器：在函数体之前执行
        // 调用本类其他构造函数时，使用this
        // 调用基类其他构造函数时，使用base
        public Car(string description) : this(description, 4)
        {
        }
        static void Main(string[] args)
        {
            Car myCar = new Car("Proton Persona");
        }
    }
}
