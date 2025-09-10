using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 힙트리
{
    //힙트리 Heap Tree
    //1. 부모가 항상 자식보다 크거나(최대힙) 작음(최소힙)
    //2. 마지막 레벨 바로 위까지는 항상 꽉 차있어야 함
    // ㄴ> 위 구조로 인해 노드의 갯수를 알면 트리의 구조를 알 수 가 있다

    //부모 노드가 가진 값이 자식 노드가 가진 값보다 크거나(최대힙), 작으면(최소힙)됨
    //양쪽 자식들 값에는 제약이 없다(부모보다 작기만 하면 됨)
    //한쪽으로 쏠릴 가능성이 있어 마지막 리프(제일 깊은 리프)를 제외하고는 
    //전부 자리가 채워져 있어야 한다 
    //채워질 때에는 왼쪽-오른쪽 순서로 무조건 채워져야 한다

    //배열(리스트)로 만들수 있기 때문에 공식 적용 가능
    //[1] (2*i)+1 i번째 노드의 왼쪽자식 접근
    //[2] (2*i)+2 i번째 노드의 오른쪽자식 접근
    //[3] (i-1)/2 i번째 노드의 부모 접근

    //삽입
    //1. 배열(리스트)의 가장 마지막 자리에 삽입
    //2. 삽입된 위치부터 부모 접근(공식 : (i-1)/2) 하여 비교를 통해 위치 변경 
    //3. 반복

    //삭제
    //1. 가장 처음 값을 뽑아냄(힙트리 사용 이유)
    //2. 가장 마지막의 값을 뽑아 처음 값으로 뽑아냄
    //3. 처음 값(위치에 있는 마지막 값)과 왼쪽자식과 오른쪽자식을 비교해서
    //4. 더 큰 경우(최대힙) or 더 작은 경우(최소힙) 쪽으로 위치변경
    //5. 반복

    //결과적으로 항상 정렬된 값을 가져올 수 있음
    //이러한 최소, 최대 힙 구조를 이용해서 힙정렬을 할 수 있고
    //우선순위 큐 또한 구현 가능

    //특정 조건에 의한 가장 좋은 솔루션을 뽑아올 때, PriorityQueue를 이용하면 빠르게 연산 가능
    //삽입, 삭제의 경우 - O(log n)의 속도가 소요된다


    //우선순위 큐 - 선입선출이 아닌 가장 큰 값부터 빠져나온다
    class PriorityQueue<T> where T : IComparable<T> //<= 얘를 상속받아 구현한 클래스만 T로써 역할 가능
    {
        List<T> _heap = new List<T>();

        public void Push(T data)//InQueue가 아닌 Push로 넣어준다
            //삽입
        {
            //일단 노드를 맨 아래에 추가
            _heap.Add(data);

            //추가된 데이터 기준으로 위로 올라가며 비교를 함
            //그럴려면 현재 위치가 필요함
            int now = _heap.Count - 1; //인덱스로 List(0)이니까 "위치"인 거임
            while(now > 0) //now의 위치가 더이상 올라갈수 없는 위치가 될 때까지
            {
                //부모 구하기
                int next = (now - 1) / 2;
                if (_heap[now].CompareTo(_heap[next])<0) //부모와 비교해서
                    break; //부모가 더 크면 걍 가만히 있음

                T temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp; //부모와 나의 위치를 스왑함

                now = next; //검사 위치 이동(포인터 이동) "위치를 next의 위치로 바꿔줌"
            }
        }

        public T Pop()
        {
            T ret = _heap[0]; //가장 큰 값, 반환 데이터 저장
            
            //루트 자식들의 위치를 업데이트함
            int lastIndex = _heap.Count - 1; //마지막인덱스라는 "포인터"를 가져옴
            _heap[0] = _heap[lastIndex]; //루트 노드의 데이터를 마지막 데이터로 교체하기
            _heap.RemoveAt(lastIndex); //마지막 인덱스를 삭제해줌
            lastIndex--; //마지막인덱스 값도 하나 줄여줌

            //맨 위를 밑으로 내려가면서 자리바꾸기를 해줌
            int now = 0;
            while(true)
            {
                //왼쪽 자식노드 구하기
                int left = (2 * now) + 1;
                //오른쪽 자식노드 구하기
                int right = (2 * now) + 2;


                int next = now; //next에 now를 넣어줌,
                                //그리고 left와 비교함. left가 더 크면 left를 next로 해줌
                if (left <= lastIndex && _heap[next].CompareTo(_heap[left]) < 0)
                    next = left; //left가 lastIndex 범위 안에 있는지, left가 next보다 크면

                if (right <= lastIndex && _heap[next].CompareTo(_heap[right]) < 0)
                    //위의 if문을 통과한 next(==left)와 right를 비교해서 next{==left)가 작다면 right와 자리 변경
                    next = right;

                //--만약, 왼쪽 오른쪽이 모두 now보다 작다면 종료한다
                if(next == now) //next를 계속 왼 오와 비교하며 내려왔는데 그 값이 now와 같아졌다 - break
                                //밑에서 now에 next값을 주고, 다시 while에서 next에 now를 넣어주는데,
                                //next값이 변경되지 않고 now와 값이 같은 채로 내려오면 break
                  break;

                //이제 두 값을 교체한다
                T temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;

                now = next;
            }
            //바로 밑 자식 - 왼쪽 노드와 오른쪽 노드를 비교
            
            return ret; //가장 큰 값 뽑아줌
        }

        public int Count()
        {
            return _heap.Count();
        }
    }
    
    class Mage
    {
        
    }

    class Knight : IComparable<Knight>
    {
        public int ID { get; set; }

        public int CompareTo(Knight other)
        {
            if(ID == other.ID)
            {  return 0; }

            return ID < other.ID ? 1 : -1;
            //부호를 변경하면 순서 또한 정렬가능
            //return ID < other.ID ? 1 : -1;
        }
    }

    internal class _250909
    {
        //static void Main(string[] args)
        //{
        //    #region PriorityQueue사용

        //    PriorityQueue<Knight> q = new PriorityQueue<Knight>();
        //    //PriorityQueue<Mage> a = new PriorityQueue<Mage>();
        //    q.Push(new Knight() { ID = 20 });
        //    q.Push(new Knight() { ID = 14 });
        //    q.Push(new Knight() { ID = 30 });
        //    q.Push(new Knight() { ID = 40 });
        //    q.Push(new Knight() { ID = 50 });
        //    q.Push(new Knight() { ID = 60 });

        //    while(q.Count() > 0)
        //    {
        //        Console.WriteLine(q.Pop().ID);
        //    }

        //    /*
        //    q.Push(-20);
        //    q.Push(-10);
        //    q.Push(-30);
        //    q.Push(-40);
        //    q.Push(-50);
        //    q.Push(-60);

        //    while (q.Count() > 0)
        //    {
        //        Console.WriteLine(-q.Pop());
        //    }
        //    이렇게 뽑으면 거꾸로 나옴 10,20,30,40,50,60
        //    */

        //    #endregion
        //}
    }
}
