#define Test
using System;
using System.Collections;
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
                //head = node.next; 가 아닌 정답 : head = head.next 라고 하는데 왜?
                node.next = head;
                //node.next.prev = null;
            }
            if(node == tail)
            {
                tail = tail.prev;
                //node.prev = tail; -> 얘가 답이 아닌 이유가 뭐야?ㅠㅠㅠ
                //node.prev.next = null;
            }
            //if(node != head && node != tail)
            //{
            //    node.prev.next = node.next;
            //    node.next.prev = node.prev;
            //}
            if(node.prev != null)
            {
                node.prev.next = node.next;
            }
            if(node.next!= null)
            {
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
        //static void Main(string[] args)
        //{
        //    List list = new List();
        //    list.Add(1);
        //    list.Add(2);    
        //    list.Add(3);
        //    list.Remove(0);

        //    LinkedList node = new LinkedList();
        //    node.Add(1);
        //    node.Add(2);
        //    node.Add(3);
        //    node.Add(4);
        //}
    }
}
namespace _스택_큐
{
    //둘 다 "선형자료구조" [][][][][]....[][][]
    
    //스택 : LIFO(Last In First Out) - 후입선출
    //큐   : FIFO(First In First Out) - 선입선출
    //--> 둘다 중간 삽입, 삭제 X
    //    리스트로 만들기 용이하다

    //스택 - 삽입은 맨뒤, 삭제도 맨뒤
    //큐   - 삽인은 맨뒤, 삭제는 맨앞
    //    순환버퍼(투포인터)로 만들기 용이하다

    class Mainn()
    {
        //static void Main(string[] args)
        //{
        //    Stack<int> stack = new Stack<int>();
        //    stack.Push(1);
        //    stack.Push(2);
        //    stack.Push(3);
        //    stack.Push(4);
        //    Console.WriteLine(stack.Pop());//->마지막게 아예 뽑혀나옴(삭제와비슷)
        //    Console.WriteLine(stack.Peek());//->값을 확인
            
        //    Queue<int> queue = new Queue<int>();
        //    queue.Enqueue(1);
        //    queue.Enqueue(2);
        //    queue.Enqueue(3);
        //    queue.Dequeue();
        //}
    }
}
namespace _열거자
{
    // 열거자(Enumerator) 
    // 어떤 데이터 집합을 순서대로 하나씩 탐색하는 기능
    // IEnumerable 인터페이스
    // IEnumerator 인터페이스
    // foreach -> 위의 두가지 인터페이스 개념위에 구축되어있음

    /*
                  [컬렉션] ──▶ GetEnumerator()
                     │
                     ▼
            ┌───────────────────┐
            │  Enumerator 객체  │
            │───────────────────│
            │ + MoveNext()      │
            │ + Current         │
            └───────────────────┘
                     │
                     ▼
            foreach 루프 실행

     Start
       │
       ▼
    [컬렉션]
       │  GetEnumerator()
       ▼
    Enumerator 생성
       │
       ▼
    while (MoveNext())
       │
       ├─ true ─▶ Current 읽기 ─▶ 루프 본문 실행 ─┐
       │                                          │
       └─ false ──────────────────────────────────┘
       │
       ▼
       End
    */

    // 배열은 연속된 저장공간에 할당
    //   []      []      []      []      [] 
    // 0x1000  0x1004  0x1008  0x1012  0x1016

    // indexer this[int index]

    // arr[7]
    // element_address = base_address + (index* sizeof(T))
    // 사용자에게는 노출 하지 않고 컴파일/JIT 이 알아서 처리를 해줍니다. 

    // Head ──▶ [10 | next] ──▶ [20 | next] ──▶ [30 | null]

    /*
     Start → node = head
        │
        ▼
        MoveNext()
        │ true
        ▼
        Current = node.Value (10)
        node = node.Next
        │
        ▼
        MoveNext()
        │ true
        ▼
        Current = node.Value (20)
        node = node.Next
        │
        ▼
        MoveNext()
        │ true
        ▼
        Current = node.Value (30)
        node = node.Next (null)
        │
        ▼
        MoveNext()
        │ false
        ▼
        End
     */

    // 유니티 
    // IEnumorator Test()
    // {
    //    yield => 내부에서 IEnumerator와 IEnumerable 인터페이스 자동구현 코드 생성
    //    
    //    return new waitForSecond(3);
    //    Consoloe.WriteLine("sdsdsd");
    // }


    // IEnumorator MoveRight()
    // {
    //    // 오른쪽 으로만 이동하는 코드
    // }

    // void MoveUp()
    // {
    //    // 위쪽 으로만 이동하는 코드
    // }

    // [프레임루프]
    //    |
    //    ㄴ StartCourutine(MoveRight) -> 호출 스택과, 내부 IEnumerator 객체의 현재 실행 지점 기억함
    //    ㄴ StartCourutine(MoveUp) -> 호출 스택과, 내부 IEnumerator 객체의 현재 실행 지점 기억함
    //    ㄴ 다른 코루틴 있는지 확인?

    // 코루틴 => 하나의 쓰레드에서 처리되는거다!


    public class MyCollection : IEnumerable
    {
        private int[] _data;

        public MyCollection(int[] data)
        {
            _data = data;
        }

        public IEnumerator GetEnumerator()
        {
            return new MyEnermerator(_data);
        }

        private class MyEnermerator : IEnumerator
        {
            private int[] _data;
            private int _position = -1; // 시작전 위치

            public MyEnermerator(int[] data)
            {
                _data = data;
            }

            public object Current
            {
                get
                {
                    if (_position < 0 || _position >= _data.Length)
                        throw new InvalidOperationException();
                    return _data[_position];
                }
            }

            public bool MoveNext()
            {
                _position++;
                return _position < _data.Length;
            }

            public void Reset()
            {
                _position = -1;
            }
        }
    }


    class Program
    {
        //static void Main()
        //{
        //    var myData = new MyCollection(new int[] { 10, 20, 30 });

        //    foreach (int item in myData)
        //    {
        //        Console.WriteLine(item);
        //    }
        //}
    }
}
namespace _그래프
{
    //from- U 정점에서 to- V 정점으로 향하는 간선이 n개 있을때 -> outdegree 가 n개이다 라고 할 수 있음
                                                          //-> 만약 v->u로 가는 간선의 갯수가 n-3이라면 indegree 는 n-3개이다 라고 할 수 있음

    class Graph
    {
        int[,] adj = new int[6,6]
        {
            {0,1,0,1,0,0 },
            {1,0,1,1,0,0 },
            {0,1,0,0,0,0 },
            {1,1,0,0,1,0 },
            {0,0,0,1,0,1 },
            {0,0,0,0,1,0 },
        };

        bool[] visited = new bool[6];


        public void DFS(int now)
        {
            //1. now부터 방문 후 방문 체크
            Console.WriteLine($"방문 {now}");
            visited[now] = true;

            //2. now와 연결된 정점들을 하나씩 확인해서
            //아직 방문하지 않은 정점을 방문
            for(int next = 0; next < adj.GetLength(0); next++)
            {
                //배열을 초과하지 않는지 확인
                if (adj[now, next] == 0) continue;

                if (visited[next] == true) continue;

                DFS(next);
            }
        }

        public void FindDFS()
        {
            visited = new bool[6];
            for(int i = 0; i< adj.GetLength(0); i++)
            {
                if (visited[i] == false)
                {
                    DFS(i);
                }
            }
        }
    }

    //백준 1012 문제
    class program
    {
        static int[,] map = new int[50, 50]; //배추밭의 넓이
        static bool[,] visited = new bool[50, 50]; //--> 배추가 모여있는 곳을 찾을때 필요
        static int[] dY = { -1, 0, 1, 0 }; //같은 i값을 주었을 때 확인할 y값의 위치
        static int[] dX = { 0, -1, 0, 1 }; //같은 i값을 주었을 때 확인할 x값의 위치
        //static int m, n, k;

        //static void DFS(int y, int x) //(0,0)으로 시작한다 치면
        //{
        //    //1. 방문처리
        //    visited[y, x] = true; //visited[0,0] = true를 넣음

        //    //2. 연결노드 확인 후 아직 방문 안한 노드 방문
        //    for(int i = 0; i< 4; i++)
        //    {                           //4방면을 체크한다
        //        int nextY = y + dY[i];  //nextY = 0+(i=0일때)-1 -> -1
        //        int nextX = x + dX[i];  //nextX = 0+(i=0일때)0  -> 0
        //        //(i = 0, nextY = -1; nextX = 0;)
        //        //(i = 1, nextY = 0; nextX = -1;)
        //        //(i = 2, nextY = 1; nextX = 0;)
        //        //(i = 3, nextY = 0; nextX = 1;)

        //        //2-1. 맵을 벗어나지 않는지 확인
        //        if (nextY < 0 || nextY >= n || nextX < 0 || nextX >= n) continue; //이경우에는 맵을 벗어났으니 continue가 됨-> for문의 int = 1인 상황으로 ㄱ

        //        if (map[nextY, nextX] == 0) continue; //1을 찾아야 함
        //        if (visited[nextY, nextX] == true) continue; //4방면의 정점들이 이미 방문했었는지에 대한 체크

        //        DFS(nextY, nextX); //위 조건들을 통과했다면 -> 해당 정점에 대해 DFS실시한다
        //    }
        //}

        //static void Main(string[] args)
        //{
        //    int m, n, k;
        //    int count = int.Parse(Console.ReadLine()); //회차 카운트
        //    while(count -- > 0)
        //    {
        //        int ret = 0;

        //        Array.Clear(map);
        //        Array.Clear(visited);
        //        //ㄴ> 초기화 해줌 -> 회차가 있으니까

        //        string[] _size = Console.ReadLine().Split();
        //        m = int.Parse(_size[0]); //배추밭 가로길이
        //        n = int.Parse(_size[1]); //배추밭 세로길이 
        //        k = int.Parse(_size[2]); //배추가 있는 "위치의 갯수"

        //        int x, y;

        //        for(int i=0;i<k;i++) //k번 만큼 x,y 좌표를 받아야 한다
        //        {
        //            _size = Console.ReadLine().Split();
        //            x = int.Parse(_size[0]);
        //            y = int.Parse(_size[1]);
        //            map[y, x] = 1; //1이 뭉쳐있는 곳을 세어야 하는거. for문을 돌면서 x,y좌표를 스페이스바로 구분해서 입력하면 map에 해당 배열 값이 1이 됨
        //        }
        //        for (int i = 0; i < n; i++) //배추밭의 세로 길이 만큼 도는데
        //        {
        //            for (int j = 0; j < m; j++) //배추밭의 가로 길이만큼 또 돈다(0,0)(0,1)(0,2)...
        //            {
        //                // 연결되있음?
        //                if (map[i, j] == 0)
        //                    continue;

        //                // 방문했음?
        //                if (visited[i, j] == true)
        //                    continue;

        //                // DFS 아 오케이 돌자
        //                DFS(i, j);

        //                // ret++; 돌고 나왔으니 덩어리 + 1
        //                ret++;
        //            }
        //        }
        //        Console.WriteLine(ret);
        //    }
        //}
    }
}

