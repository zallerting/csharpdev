using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadonlyTest
{
    class Document
    {
        // 创建只读的静态字段
        public static readonly int MaxDocuments;
        // 创建只读的实例字段
        public readonly DateTime CreationDate;
        // 只读的静态字段只能在静态构造器中修改
        static Document()
        {
            MaxDocuments = 100;
        }
        // 只读的实例字段只能在普通构造器中修改
        public Document()
        {
            // Read in creation date from file. Assume result is Mar, 9th, 2017
            // but in general this can be different for different instances of 
            // the class.
            CreationDate = new DateTime(2017, 3, 9);
        }
        static void Main(string[] args)
        {
            Document document = new Document();
            Console.Read();
        }
    }
}
