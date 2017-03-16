using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            // 声明锯齿数组
            int[][] jagged = new int[3][];
            jagged[0] = new int[2] { 1,2};
            jagged[1] = new int[6] { 3,4,5,6,7,8};
            jagged[2] = new int[3] { 9, 10, 11 };
            // 迭代显示锯齿数组的所有元素
            for(int row = 0; row < jagged.Length; row++)
            {
                for (int element = 0; element < jagged[row].Length; element++)
                {
                    Console.WriteLine("row:{0}, element:{1}, value:{2}",row,element,jagged[row][element]);
                }
            }
            Console.Read();
        }
    }
}
