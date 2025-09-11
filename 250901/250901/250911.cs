using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 전치출력
{
    internal class _250911
    {
        static void Main(string[] args)
        {
            int[,] arr = new int[,]
            {
                {1,2,3 },
                {4,5,6 },
                {7,8,9 }
            };
            //int[,] arrs = arr;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{arr[j,i]}");
                    Console.WriteLine();
                }
            }


            int[,] map =
            {
                {1,1,1 },
                {1,1,1 },
                {1,1,1 }
            };

            //주어진 x,y좌표값의 상하좌우 4방향의 인덱스 값에 1을 더하여 출력
            void four(int x, int y)
            {
                if (x + 1 >= map.GetLength(0) || x - 1 < 0 || y + 1 >= map.GetLength(1) || y - 1 < 0) return;
                 map[x + 1, y]++;
                 map[x - 1, y]++;
                 map[x, y + 1]++;
                 map[x, y - 1]++;
            }
            four(1, 1);
            Console.WriteLine(map[1,2]);
        }
    }
}
