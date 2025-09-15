#define Test
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250901
{
    internal class ImportantAttribute : Attribute
    {
        public string message;

        public ImportantAttribute(string message)
        {
            this.message = message;
        }
    }

    //Nullable - Null + able
    [ImportantAttribute("몬스터 클래스 입니다")]
    class Monster
    {
        public int ID;
        public Monster MatchID(int id)
        {
            if (this.ID == id)
                return this;
            return null;
        }
    }

    class Mainin
    {

        [Conditional("Test")]//이걸 붙여주게 되면 - 만약 맨 위에 #define로 정의가 되어있을 때만 실행이 된다
        static void Test()
        {
            Console.WriteLine("Test가 정의되어있음");
        }

        //static void Main(string[] args)
        //{
        //    Monster monster = new Monster();
        //    Type type = monster.GetType(); //형식 - 클래스 에 대한 정보를 반환\
        //    var fields = type.GetFields();
        //    Test();

        //    Monster mon = new Monster() { ID = 20 };
        //    Monster found = mon.MatchID(20); //참조타입이라 null이어도 return 이 가능하다

        //    //int a = null (X) 불가능
        //    int? a = null; //null을 넣을 수 있음
        //    int? c = new Nullable<int>();
        //    c = 8;
        //    a = 3;
        //    if(a.HasValue == true)
        //    {
        //        //int b = a.Value; //int b = a (X) 불가능
        //        int b = a.Value;
        //        Console.WriteLine(b);
        //    }
        //}
    }
}
namespace _시간복잡도
{
    class Program
    {
        //시간복잡도 - 주요 로직의 반복 횟수를 중심으로 측정
        //BigO 표기법 - 최고차항을 제외한 요소들은 무시한다 - 4 + n^2 여도 n^2로 표기

        //선형자료구조 - 자료를 순차적으로 나열 
        //  배열, 리스트, 연결리스트, 스택, 큐
        //      배열 - 처음 설정한 크기가 고정되어 변경이 불가, 메모리상에 연속된 형태로 데이터가 저장
        //             장점 : 데이터연속 / 단점 : 추가,삭제 불가능
        //      리스트 - 내부적으로는 배열 기반으로 동작, 크기가 꽉 차면 길이가 1.5~3배인 배열을 만들고 기존의 데이터를 복사
        //              장점 : 크기 확장 자동처리 / 단점 : "중간" 삽입, 삭제 느림(맨 앞, 맨 뒤는 빠름)
        //      연결리스트 - 각 원소가 데이터+ (다음 노드,이전노드) 주소를 들고 있음, 메모리상 연속적인 배치는 X
        //              장점 : 중간 삽입,삭제 빠름 / 단점 : 특정 위치 검색이 느림(인덱스 접근 불가능)

        //비선형자료구조 - 딕셔너리, 트리, 그래프
        //  딕셔너리, 트리, 그래프
        //      딕셔너리 - 장점 : 순서가 섞여있어도 특정 위치 검색이 빠르다(해시구조를 가용하여 키값을 인덱싱한다 - 그래서 빠름)


        //static void Test(int n)
        //{
        //    int sum = 0;
        //    for (int i = 0; i < n; i++) //n번 반복
        //    {
        //        for (int j= 0; j < n; j++) //n번 마다 n번 반복
        //        {
        //            sum += 1;
        //        }
        //        //--> 1 + n^2

        //        sum = 0;
        //        //--> 1 + n^2 + 1
        //        //연산되는 "횟수"
        //    }
        //}

        //static void Main(string[] args)
        //{
        //    Stopwatch sw = new Stopwatch();
        //    sw.Start();
        //    int sum = 0;
        //    for(int i = 0; i < 1_000_000; i++)
        //    {
        //        sum += i;
        //    }
        //    sw.Stop();
        //    Console.WriteLine($"Elapsed Time : {sw.ElapsedMilliseconds}");
        //}

    }



    class List
    {
        public int indexValue { get { return list.Length; } }
        public int nowindex = 0;
        public int[] list = new int[1];

        public void Add(int a)
        {
            if(nowindex >= list.Length)
            {
                int[] ints = new int[indexValue * 2];
                for(int i = 0; i < indexValue; i++)
                {
                    ints[i] = list[i];
                }
                list = ints;
            }
            list[nowindex] = a;
            Console.WriteLine($"{indexValue} // {nowindex}");
            nowindex++;
        }
        public void Remove(int index)
        {
            Console.WriteLine($"{index} = {list[index]}");
            for(int i = 0;i < indexValue-1;i++)
            {
                list[i] = list[i+1];
                list[indexValue - 1] = 0;
            }
            Console.WriteLine($"//--> {index} = {list[index]}");
            nowindex--;
        }
    }
    class LinkedList
    {
        Node head = null;
        Node tail;

        int count;
        public void Add(int a)
        {
            Node newnode = new Node();
            newnode.value = a;

            if(head == null) 
            {
                head = newnode;
                
            }
            if(tail != null)
            {
                tail.next = newnode;
                newnode.prev = tail;
            }
            
            tail = newnode;

            count++;
        }

        public void RemoveAt(Node node)
        {
            if(node == head)
            {
                node.next = head;
                node.next.prev = null;
            }
            if(node == tail)
            {
                node.prev = tail;
                node.prev.next = null;
            }
            if(node != head && node != tail)
            {
                node.prev.next = node.next;
                node.next.prev = node.prev;
            }
        }
    }
    class Node
    {
        public int value;
        public Node next;
        public Node prev;
    }

    class Program2
    {
        static void Main(string[] args)
        {
            List list = new List();
            list.Add(1);
            list.Add(2);    
            list.Add(3);
            list.Remove(0);

            LinkedList node = new LinkedList();
            node.Add(1);
            node.Add(2);
            node.Add(3);
            node.Add(4);
        }
    }
}
