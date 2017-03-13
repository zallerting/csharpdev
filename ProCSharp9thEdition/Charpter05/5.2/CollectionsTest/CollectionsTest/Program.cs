using System;
using System.Collections;
using System.Collections.Generic;

namespace CollectionsTest
{
    // 创建泛型类LinkedListNode<T>
    class LinkedListNode<T>
    {
        // 包含一个属性Value
        public T Value
        {
            get;
            private set;
        }
        // 通过构造函数对属性Value进行初始化
        public LinkedListNode(T value)
        {
            this.Value = value;
        }
        // 包含对链表下一个元素及上一个元素的引用
        public LinkedListNode<T> Next
        {
            get;
            internal set;
        }
        public LinkedListNode<T> Prev
        {
            get;
            internal set;
        }
    }
    // 创建泛型类LinkedList<T>派生至泛型类IEumerable<T>，
    // 泛型类IEumerable<T>派生至IEumerable类
    class LinkedList<T>:IEnumerable<T>
    {
        // 创建LinkedListNode<T>类型的对象，分别标记链表头尾
        public LinkedListNode<T> First
        {
            get;
            private set;
        }
        public LinkedListNode<T> Last
        {
            get;
            private set;
        }
        // AddLast方法在链表尾部添加一个新元素
        public LinkedListNode<T> AddLast(T node)
        {
            var newNode = new LinkedListNode<T>(node);
            // 当链表是空的时候，First及Last设置为该新元素
            if (First == null)
            {
                First = newNode;
                Last = First;
            }
            else // 否则将新元素添加为链表中的最后一个元素
            {
                LinkedListNode<T> previous = First;
                Last.Next = newNode;
                Last = newNode;
                Last.Prev = previous;
            }
            return newNode;
        }
        // 实现IEnumerator<T>的GetEnumerator()方法
        public IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> current = First;
            while (current != null)
            {
                // 使用yield语句创建一个枚举器类型
                yield return current.Value;
                current = current.Next;
            }
        }
        // 实现IEnumerator的GetEnumerator()方法
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    class MainEntryPoint
    {
        static void Main()
        {
            var list = new LinkedList<int>();
            list.AddLast(1);
            list.AddLast(3);
            list.AddLast(5);
            foreach (int i in list)
            {
                Console.WriteLine(i);
            }

            var list2 = new LinkedList<string>();
            list2.AddLast("丁煜珩");
            list2.AddLast("丁正龙");
            list2.AddLast("丁德军");
            foreach (string str in list2)
            {
                Console.WriteLine("str = " + str);
            }
            Console.Read();
        }
    }
}
