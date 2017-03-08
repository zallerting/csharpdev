using System;
// 创建名称空间别名
using Introduction = Wrox.ProCSharp.namespaceTest;

namespace Wrox.ProCSharp.namespaceTest
{
    class NamespaceTest
    {
        public String getNamespace()
        {
            return this.GetType().Namespace;
        }
    }
}

class Test
{
    public static void Main(String[] args)
    {
        // 通过名称空间别名中的类创建引用变量
        Introduction::NamespaceTest nst = new Introduction::NamespaceTest();
        Console.WriteLine(nst.getNamespace());
        Console.ReadLine();
    }
}