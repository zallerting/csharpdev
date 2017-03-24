using System;
using System.Windows;

namespace WeakEventDemo
{
    public class CarInfoEventArgs : EventArgs // EventArgs表示包含事件数据的类的基类
    {
        // 创建属性
        public string Car { get; private set; }
        // 创建构造函数
        public CarInfoEventArgs(String car)
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
        public virtual void RaiseNewCarInfo(string car)
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
    // 事件侦听器，实现IWeakEventListener接口
    public class Consumer:IWeakEventListener
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
        // 实现ReceiveWeakEvent()接口方法，触发事件时，从弱事件管理器中调用这个方法
        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            // 触发事件时调用NewCarIsHere()方法
            NewCarIsHere(sender, e as CarInfoEventArgs);
            return true;
        }
    }
    // 创建派生自WeakEventManager类的弱事件管理器类
    public class WeakCarInfoEventManager:WeakEventManager
    {
        // 创建静态属性，访问WeakCarInfoEventManager类中的单态对象
        public static WeakCarInfoEventManager CurrentManager
        {
            get
            {
                // 返回为提供的类型的WeakEventManager对象
                var manager = GetCurrentManager(typeof(WeakCarInfoEventManager))
                    as WeakCarInfoEventManager;
                if (manager == null)
                {
                    manager = new WeakCarInfoEventManager();
                    // 设置指定的管理器类型的当前管理器
                    SetCurrentManager(typeof(WeakCarInfoEventManager), manager);
                }
                // 返回WeakCarInfoEventManager类的单态对象的引用
                return manager;
            }
        }
        // DeliverEvent()方法在侦听器中调用IWeakEventListener接口中的ReceiveWeakEvent()方法
        void CarDealer_NewCarInfo(object sender, CarInfoEventArgs e)
        {
            // 提供托管事件，每个侦听器。
            DeliverEvent(sender, e);
        }
        // 创建静态方法，进行连接发布程序而不是直接使用发布程序中的事件
        public static void AddListener(object source, IWeakEventListener listener)
        {
            // 添加所提供的侦听器添加到托管事件的提供的源
            CurrentManager.ProtectedAddListener(source, listener);
        }
        // 创建静态方法，进行断开发布程序而不是直接放弃使用发布程序中的事件
        public static void RemoveListener(object source, IWeakEventListener listener)
        {
            // 从所提供的源代码中移除以前添加的侦听器
            CurrentManager.ProtectedRemoveListener(source, listener);
        }
        // 重写WeakEventManager类的StartListening()方法
        // 添加第一个侦听器时使用StartListening()方法，从弱事件管理器订阅一个方法
        protected override void StartListening(object source)
        {
            // 源对象中检查类型信息，之后进行强制类型转换
            (source as CarDealer).NewCarInfo += CarDealer_NewCarInfo;
        }
        // 重写WeakEventManager类的StopListening()方法
        // 删除最后一个侦听器时使用StopListening()方法，从弱事件管理器取消订阅一个方法
        protected override void StopListening(object source)
        {
            (source as CarDealer).NewCarInfo -= CarDealer_NewCarInfo;
        }
    }
    public class MainEntryPoint
    {
        public static void Main(String[] args)
        {
            // 连接发布程序和侦听器
            // 该连接现在使用WeakCarInfoEventManager类的AddListener()和RemoveListener()静态方法
            var dealer = new CarDealer();
            var michael = new Consumer("Michael");
            WeakCarInfoEventManager.AddListener(dealer, michael);
            dealer.NewCar("Mercedes");

            var sebastian = new Consumer("Sebastian");
            WeakCarInfoEventManager.AddListener(dealer, sebastian);
            dealer.NewCar("Ferrari");
            // 实现了弱事件模式后，发布程序和侦听器就不再强制连接了。
            // 当不再引用侦听器时，它就会被垃圾回收。
            WeakCarInfoEventManager.RemoveListener(dealer, michael);
            dealer.NewCar("Red Bull Racing");

            Console.WriteLine();

            // 泛型弱事件管理器
            var deal = new CarDealer();
            var alvin = new Consumer("Alvin");
            WeakEventManager<CarDealer, CarInfoEventArgs>.AddHandler(dealer,
                "NewCarInfo", alvin.NewCarIsHere);
            dealer.NewCar("Mercedes");

            var zaller = new Consumer("Zaller");
            WeakEventManager<CarDealer, CarInfoEventArgs>.AddHandler(dealer,
                "NewCarInfo", zaller.NewCarIsHere);
            dealer.NewCar("Ferrari");

            WeakEventManager<CarDealer, CarInfoEventArgs>.RemoveHandler(dealer,
                "NewCarInfo", alvin.NewCarIsHere);
            dealer.NewCar("Red Bull Racing");

            Console.Read();
        }
    }
}
