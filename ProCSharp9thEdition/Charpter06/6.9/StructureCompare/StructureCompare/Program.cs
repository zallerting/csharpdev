using System;
using System.Collections;
using System.Collections.Generic;

namespace StructureCompare
{
    class Person : IEquatable<Person>
    {
        // 创建Id、FirstName、LastName属性
        public int Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // 定义强类型化Equals()方法
        public bool Equals(Person other)
        {
            if (other == null)
                return base.Equals(other);
            return this.Id == other.Id && this.FirstName == other.FirstName
                && this.LastName == other.LastName;
        }
        // 重写IEquatable<Person>的Equals()方法
        public override bool Equals(object obj)
        {
            if (obj == null)
                return base.Equals(obj);
            // 调用强类型化的Equals()方法
            return this.Equals(obj as Person);
        }
        // 重写Object的ToString()方法
        public override string ToString()
        {
            return String.Format("{0} {1} {2}", this.Id, this.FirstName, this.LastName); 
        }
        // 重写Object的GetHashCode()方法
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
    // IEqualityComparer：定义方法以支持对象的相等比较
    class TupleComparer : IEqualityComparer 
    {
        // 实现IEqualityComparer接口的Equals()方法
        // 因为Object类也定义了带两个参数的静态Equals()方法，
        // 所以此处实现的Equals()方法需要new关键字修饰
        public new bool Equals(object x, object y)
        {
            return x.Equals(y);
        }
        // 实现IEqualityComparer接口的GetHashCode()方法
        public int GetHashCode(object obj)
        {
            return obj.GetHashCode();
        }
    }
    class MainEntryPoint
    {
        static void Main(String[] args)
        {
            // 创建一个Person类对象
            var janet = new Person { FirstName = "janet", LastName = "Jackson" };
            // 创建两个内容相同的不同Person类对象
            Person[] person1 = {
                new Person {
                    FirstName = "Michael",
                    LastName = "Jackson"
                },
                janet
            };
            Person[] person2 = {
                new Person {
                    FirstName = "Michael",
                    LastName = "Jackson"
                },
                janet
            };
            // 比较两个不同的数组，引用不同故不相等
            if (person1 != person2)
            {
                Console.WriteLine("person1 has not the same reference with person2.");
            }
            // 比较两个不同数组的内容，内容相同故相等
            // IStructuralEquatable接口定义的Equals()方法，第一个参数为Object类型，第
            // 二个参数为IEqualityComparer类型。通过EqualityComparer<T>类完成IEqualityComparer
            // 的一个默认实现，返回一个默认的相等比较器，用于比较此泛型参数指定的类型。
            if ((person1 as IStructuralEquatable).Equals(person2,
                EqualityComparer<Person>.Default))
            {
                Console.WriteLine("person1 has the same content with person2.");
            }
            // 创建两个内容相同的元组实例
            var t1 = Tuple.Create<int, string>(1, "Stephanie");
            var t2 = Tuple.Create<int, string>(1, "Stephanie");
            // 比较两个不同二元组，引用不同故不相等
            if (t1 != t2)
            {
                Console.WriteLine("t1 has not the same reference with t2.");
            }
            // 比较元组内容，内容相同故相等
            if (t1.Equals(t2))
            {
                Console.WriteLine("t1 has the same content with t2.");
            }
            // IStructuralEquatable：定义方法以支持对象的结构相等性比较
            if ((t1 as IStructuralEquatable).Equals(t2, new TupleComparer()))
            {
                Console.WriteLine("equals using TupleComparer.");
            }

            Console.Read();
        }
    }
}
