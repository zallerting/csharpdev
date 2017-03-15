using System;

namespace GenericsInterface
{
    public class Shape
    {
        // 定义Shape类的成员字段
        public double Width { get; set; }
        public double Height { get; set; }
        // 重写Object类的ToString()方法
        public override string ToString()
        {
            return String.Format("Width:{0}, Height:{1}", Width, Height);
        }
    }
    // Rectangle类派生至Shape类
    public class Rectangle : Shape {}
    // 泛型类型用out关键字标注，泛型接口就是协变的，派生程度更大的类型
    public interface IIndex<out T>
    {
        // 定义索引器及Count属性
        T this[int index] { get; }
        int count { get; }
    }
    // 泛型类型用in关键字标注，泛型接口就是抗变的，派生程度更小的类型
    public interface IDisplay<in T>
    {
        void Show(T item);
    }
    // 实现IIndex<Rectangle>泛型接口
    public class GenericsRectangle : IIndex<Rectangle>
    {
        private Rectangle[] data = new Rectangle[3]
            {
                new Rectangle { Width=2, Height=5},
                new Rectangle { Width=3,Height=7},
                new Rectangle { Width=4.5,Height=2.9}
            };
        // 实现IIndex<Rectangle>泛型接口的方法
        public Rectangle this[int index]
        {
            get
            {
                if (index < 0 || index > data.Length)
                {
                    throw new ArgumentOutOfRangeException("index");
                }
                return data[index];
            }
        }
        public int count
        {
            get
            {
                return data.Length;
            }
        }
        private static GenericsRectangle gr;
        public static GenericsRectangle GetRectangle()
        {
            // ??为合并运算符：若gr为null将调用运算符右侧以创
            // 建一个GenericsRectangle实例，并将其赋给变量gr
            return gr ?? (gr = new GenericsRectangle());
        }
    }
    // 实现IDisplay<Shape>泛型接口
    public class ShapeDisplay : IDisplay<Shape>
    {
        // 实现IDisplay<Shape>泛型接口的方法
        public void Show(Shape s)
        {
            Console.WriteLine("{0} Width:{1}, Height:{2}",s.GetType().Name, s.Width, s.Height);
        }
    }
    class MainEntryPoint
    {
        static void Main(String[] args)
        {
            // 协变
            IIndex<Rectangle> rectangles = GenericsRectangle.GetRectangle();
            IIndex<Shape> shapes = rectangles;
            // 使用接口中的索引器和Count属性
            for (int i = 0; i < shapes.count; i++)
            {
                Console.WriteLine(shapes[i]);
            }
            
            // 抗变
            IDisplay<Shape> shapeDisplay = new ShapeDisplay();
            IDisplay<Rectangle> rectangleDisplay = shapeDisplay;
            rectangleDisplay.Show(rectangles[0]);

            Console.Read();
        }
    }
}
