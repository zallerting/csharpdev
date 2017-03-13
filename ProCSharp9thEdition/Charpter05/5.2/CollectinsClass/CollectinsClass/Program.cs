using System;
using System.Collections;

namespace CollectionsClass
{
    class LinkedListNode
    {
        // 包含一个属性Value
        public object Value
        {
            get;
            private set;
        }
        // 通过构造函数对属性Value进行初始化
        public LinkedListNode(object value)
        {
            this.Value = value;
        }
        // 包含对链表下一个元素及上一个元素的引用
        public LinkedListNode Next
        {
            get;
            internal set;
        }
        public LinkedListNode Prev
        {
            get;
            internal set;
        }
    }
    // LinkedList实现IEnumerable接口，IEnumerable
    // 接口支持在非泛型集合上进行简单迭代
    class LinkedList:IEnumerable
    {
        // 创建LinkedListNode类型的对象，分别标记链表头尾
        public LinkedListNode First
        {
            get;
            private set;
        }
        public LinkedListNode Last
        {
            get;
            private set;
        }
        // AddLast方法在链表尾部添加一个新元素
        public LinkedListNode AddLast(object node)
        {
            var newNode = new LinkedListNode(node);
            // 当链表是空的时候，First及Last设置为该新元素
            if (First == null)
            {
                First = newNode;
                Last = First;
            }
            else // 否则将新元素添加为链表中的最后一个元素
            {
                LinkedListNode previous = First;
                Last.Next = newNode;
                Last = newNode;
                Last.Prev = previous;
            }
            return newNode;
        }
        // IEnumerator支持对非泛型类型的简单迭代
        // 实现GetEnumerator方法使用yield语句创建一个枚举器类型
        public IEnumerator GetEnumerator()
        {
            LinkedListNode current = First;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        static void Main(string[] args)
        {
            // 实例化一个LinkedList对象 
            var list = new LinkedList();
            list.AddLast(4);
            list.AddLast(6);
            list.AddLast("8");
            foreach (int i in list)
            {
                Console.WriteLine("i = " + i);                
            }
            Console.Read();
        }
    }
}
