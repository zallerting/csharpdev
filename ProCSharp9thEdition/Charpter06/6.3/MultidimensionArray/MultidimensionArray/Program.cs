using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultidimensionArray
{
    class Program
    {
        static void Main(String[] args)
        {
            // 声明二维数组
            int[,] twodim = new int[3, 3];
            twodim[0, 0] = 1;
            twodim[0, 1] = 2;
            twodim[0, 2] = 3;
            twodim[1, 0] = 4;
            twodim[1, 1] = 5;
            twodim[1, 2] = 6;
            twodim[2, 0] = 7;
            twodim[2, 1] = 8;
            twodim[2, 2] = 9;
            // 声明二维数组
            int[,] twodim2 = {
                {1,2,3},
                { 4,5,6},
                { 7,8,9}
            };
            // 声明三维数组
            int[,,] threedim = {
                { { 1,2}, { 3,4} },
                { { 5,6}, { 7,8} },
                { { 9,10}, { 11,12} }
            };
        }
    }
}
