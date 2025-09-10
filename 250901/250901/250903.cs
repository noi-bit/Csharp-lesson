using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250901
{
    //수업관련 X
    /*어떠한 특정 수를 받아서 0~그 수까지 랜덤하게 그 수만큼의 배열에 각각 넣어주세요 -특정한 수 : n 랜덤으로 0*/
    class arr
    {
        protected int i;
        protected int protect = 10;
        public int ac { get; set; }
        public int ab = 1;
        
        public arr(int i, int a) 
        {
            this.i = i;
            this.ac = a;
            ab = 2;
            Console.WriteLine(protect);
            Console.WriteLine(i);
            Console.WriteLine(ac);
            Console.WriteLine(ab);
        }

        public virtual void a()
        {
            Console.WriteLine(i);
            Console.WriteLine("부모가 정의한 함수 a");
        }

        public void makingarr()
        {
            int[] list = new int[i];
            
            for(int i = 0; i < list.Length; i++)
            {
                list[i] = new Random().Next(0, i);
            }
            Console.WriteLine(list[i-1]);
        }

        
    }

    class arrda : arr
    {
        public arrda(int i, int ac) : base(i,ac)
        {
            Console.WriteLine(protect);
        }
        public void no()
        {

        }
        public override void a()
        {
            
        }
        //public void a()
        //{
        //    Console.WriteLine(i);
        //    Console.WriteLine("자식이 정의한 함수 a");
        //}
    }

    public struct noi()
    {
        public int a=3;
        public int b=4;

        public void plus(int a, int b)
        {
            
            Console.WriteLine(a+b);
        }
    }

    public class _noi
    {
        public int a = 4;
    }

    public class Noi<T>(int b)
    {
        public T a;
        public Noi<T> y;
       
    }
    class MyList4<T>
    {
        public static int b = 0;
        int a;
        public MyList4(int a)
        {
            this.a = a;
        }

    }

    internal class _250903
    {
        public static void plus(object a)
        {
            a = (int)a;
        }

        //static void Main(string[] args)
        //{
        //    noi noi1 = new noi();
        //    Console.WriteLine(noi1.a);
        //    plus(noi1.a);
        //    Console.WriteLine(noi1.a);

        //    _noi noi2 = new _noi();
        //    Console.WriteLine(noi2.a);
        //    plus(noi2.a);
        //    Console.WriteLine(noi2.a);
        //    int aa = MyList4<int>.b;
        //    Console.WriteLine(aa);
        //    float a = 30;
        //}
    }
}
