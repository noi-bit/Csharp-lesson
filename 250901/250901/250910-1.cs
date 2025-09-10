using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250901
{
    internal class _250910_1
    {
        //선택정렬 : 교환은 적지만 비교가 많음
        //버블정렬 : 비교와 교환이 동시에 많이 발생
        //평균 시간 복잡도 : O(n^2)

        //최소값을 찾아서 맨 앞으로 보내기 - 선택정렬
        //자기 옆과 비교해서 최댓값 점점 뒤로 보내기 - 버블정렬

    }
}

//카운팅스타 (counting str) -> 문자열
//카운팅배열 (counting arr) -> 배열

namespace homeWork
{
    
    class Truck
    {
        //주차요금
        static void Main(string[] args)
        {
            int[] time = new int[100];
            string[] inputs = (Console.ReadLine().Split());
            int[] moneys = new int[inputs.Length];
            for(int i = 0; i < inputs.Length; i++)
            {
                moneys[i] = int.Parse(inputs[i]);
            } //주차요금 받아서 배열로 저장 A,B,C

            //A트럭이 도착했다 떠난 시간, B트럭이 도착했다 떠난 시간, C트럭이 도착했다 떠난 시간
            string[] inputA = Console.ReadLine().Split();
            int Aar = int.Parse(inputA[0]);
            int Ago = int.Parse(inputA[1]);
            string[] inputB = Console.ReadLine().Split();
            int Bar = int.Parse(inputB[0]);
            int Bgo = int.Parse(inputB[1]);
            string[] inputC = Console.ReadLine().Split();
            int Car = int.Parse(inputC[0]);
            int Cgo = int.Parse(inputC[1]);


            if (Ago > 100 || Bgo > 100 || Cgo > 100)
                return;

            //Aar = 1, Ago = 6일때 A가 머물렀던거는 time[0]~time[5]까지
            //Bar = 3, Bgo = 5일때 B = time[2]~time[4]까지

            for (int i = Aar; i< Ago; i++)
            {
                time[i]++; //이러면  time[0]~time[5] 가 1이 됨 {1,1,1,1,1,0,0,0,0,0....}
            }
            for(int i = Bar; i< Bgo; i++)
            {
                time[i]++;
            }
            for (int i = Car; i < Cgo; i++)
            {
                time[i]++;
            }

            int money = 0;
            for(int i = 0; i<time.Length; i++)
            {
                if (time[i] == 0)
                    continue;
                if (time[i] == 1)
                    money += (moneys[0]*1);
                
                if (time[i] == 2)
                    money += (moneys[1]*2);
               
                if (time[i] == 3)
                    money += (moneys[2]*3);
               
            }
            Console.WriteLine(money);
        }
    }
}
