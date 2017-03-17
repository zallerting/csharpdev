using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayAsReference
{
    class Program
    {
        // 创建分隔一维数组一部分的方法
        static int SumOfSegments(ArraySegment<int>[] segments)
        {
            int sum = 0;
            foreach (var segment in segments)
            {
                // segment.Offset:获取由数组段分隔的范围中的第一个元素的位置(相对于原始数组的开始位置)
                // segment.Count:获取由数组段分隔的范围中的元素个数
                for (int i = segment.Offset; i < segment.Offset + segment.Count; i++)
                {
                    // segment.Array[i]:获取原始数组，其中包含数组段分隔的元素范围
                    sum += segment.Array[i];
                }
            }
            return sum;
        }
        static void Main(string[] args)
        {
            int[] ar1 = { 1, 4, 5, 11, 13, 18};
            int[] ar2 = { 3, 4, 5, 18, 21, 27, 33};
            // 创建并初始化分隔一维数组一部分的数组
            var segments = new ArraySegment<int>[2]
            {
               // 初始化ArraySegment<T>结构的新结构，该结构用于分隔指定数组中指定的元素范围
               new ArraySegment<int>(ar1, 0, 3),
               new ArraySegment<int>(ar2, 3, 3)
            };
            var sum = SumOfSegments(segments);
            Console.WriteLine("sum = " + sum);
            Console.Read();
        }
    }
}
