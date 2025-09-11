using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250901
{
    internal class _250911
    {
        static void Main(string[] args)
        {
            void Swap(int a, int b)
            {
                Console.WriteLine($"a:{a}b:{b}");

                int temp = a;
                a = b;
                b = temp;
                Console.WriteLine("바꾼후");
                Console.WriteLine($"a:{a}b:{b}");
            }

            Swap(3, 5);
        }
    }
}
