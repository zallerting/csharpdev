using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDemo
{
    public class CarInfoEventArgs:EventArgs // EventArgs表示包含事件数据的类的基类
    {
        public string Car { get; private set; }
        public CarInfoEventArgs(string car)
        {
            this.Car = car;
        }
    }
    // 事件发布程序
    public class CarDealer
    {
        // 定义事件：表示将在事件提供数据时处理该事件的方法
        // EventHandler<TEventArgs>定义一个处理程序：
        // 返回void，接受两个参数；
        // 第1个参数必须为object类型，第2个参数为T类型；
        // 还定义一个关于T的约束，必须派生自基类EventArgs；
        public event EventHandler<CarInfoEventArgs> NewCarInfo;
        public void NewCar(string car)
        {
            Console.WriteLine("CarDealer, new car {0}", car);
            // 通过调用RaiseNewCarInfo()方法触发NewCarInfo事件
            RaiseNewCarInfo(car);
        }
        protected virtual void RaiseNewCarInfo(string car)
        {
            // Delegate类的GetInvocationList()按照调用顺序返回此多路广播委托的调用列表
            var newCarInfo = NewCarInfo.GetInvocationList();
            // 该方法的实现检查委托是否不为空，若不为空就触发事件
            if (newCarInfo != null)
            {
                // 事件一般采用带两个参数的方法：
                // 第1个参数是一个对象，包含事件的发送者；
                // 第2个参数提供了事件的相关信息；
                NewCarInfo(this, new CarInfoEventArgs(car));
            }
        }
    }
    // 事件侦听器
    public class Consumer
    {
        private string name;
        public Consumer(string name)
        {
            this.name = name;
        }
        // 该方法满足EventHandler<CarInfoEventArgs>委托的要求
        public void NewCarIsHere(object sender, CarInfoEventArgs e)
        {
            Console.WriteLine("{0}: car {1} is new", name, e.Car);
        }
    }
    // 连接事件发布程序和订阅器
    class MainEntryPoint
    {
        static void Main(String[] args)
        {
            var dealer = new CarDealer();
            var michael = new Consumer("Michael");
            // 通过"+="创建一个订阅
            dealer.NewCarInfo += michael.NewCarIsHere;
            dealer.NewCar("Ferrari");

            var sebastian = new Consumer("Sebastian");
            dealer.NewCarInfo += sebastian.NewCarIsHere;
            dealer.NewCar("Mercedes");
            
            // 通过"-="取消一个订阅
            dealer.NewCarInfo -= michael.NewCarIsHere;

            dealer.NewCar("Red Bull Racing");

            Console.Read();
        }
    }
}
