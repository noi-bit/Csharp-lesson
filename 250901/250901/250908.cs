using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250901_이진_검색_트리_binary_search_tree_BST
{
    //루트 기준으로
    //왼쪽은 루트보다 작은 값,
    //오른쪽은 루트보다 큰 값
    //잘 정리되어있다는 기준으로 값을 빠르게 찾기 가능 (시간복잡도 : O(log n))

    //정렬된 값을 넣을 경우(90,91,92) 트리의 균형이 깨질 수 있다
    //-> 균형이 깨진 이진 검색 트리는 탐색 속도가 느려진다
    //  -> 정렬된 값중 특정 값을 찾기 위해서는 리스트 탐색과 같이 O(n)의 시간복잡도가 소요된다

    //평균 : O(log n)
    //최악 : O(n) (트리가 한쪽으로 치우쳐져 사실상 연결 리스트가 되었을 때)

    //균형이 맞지 않는 트리   - 편향트리(skewed tree)
    //균형이 완벽히 맞는 트리 - 완전 이진트리(perfect binary tree)
    //BST에는 강제로 균형을 유지하는 규칙은 없다
    //입력 데이터의 순서에 따라 최선과 최악이 나옴

    //자기 균형 이진 탐색 트리(self - balancing BST)
    //균형이 깨지는 걸 대비하기 위해 스스로 복구하는 "균형 트리" 라는것이 있다
    //추가적으로 삽입시, 스스로 균형을 유지하게끔 만들어진 트리
    //1.AVL 2.RedBlack tree 3.B Tree
    //1.AVL           - 강제로 높이 차이를 1 이내로 제한, 아주 강하게 균형을 잡는다.
    //                  ㄴ> 균형을 강하게 잡는 대신, 연산이 많이 이루어짐
    //2.RedBlack tree - 균형 유지시 조금 느슨한 제한을 걸어둔다
    //                  ㄴ> 연산은 상대적으로 적으나, 구현이 매우 어렵다
    // ※ 최악이나 최선이나 항상 O(log n)의 시간을 보장한다 ※

    //레드블랙 트리는 스스로 균형을 유지하는 이진 탐색트리의 한 종류
    //구현 개념은 빨강, 검정이라는 색의 개념을 도입
    //색과 규칙을 통해 편향트리가 발생되지 않도록 함
    //레드블랙 트리의 규칙(5가지)
    //  1. 모든 노드는 빨강 or 검정이다
    //  2. 루트는 항상 검정이다
    //  3. 모든 리프(NIL)은 검정이다
    //  4. 빨강 노드의 자식은 항상 검정 노드이다 (빨강-빨강 불가능)
    //  5. 루트에서 어떤 리프까지 가는 모든 경로에 있는 검정노드 개수는 동일하다

    //항상 삽입, 삭제, 탐색 O(log n) 시간이 보장이 된다
    
    //if 면접질문이라면 ? 레드블랙 트리가 무엇인가요?
    //                  - 자기 균형 이진 탐색 트리의 한 종류입니다
    //                  - 노드에 색을 부여하고, 특정 규칙을 통해 트리 높이가 log n 에 머물도록 보장합니다
    //                  - 삽입, 삭제, 탐색, 최악의 경우에도 모두 O(log n) 성능을 가집니다

    class BstNode<T>
    {
        public int Key; //트리의 노드값들
        public T Value;
        public BstNode<T> Left; //왼쪽 자식
        public BstNode<T> Right; //오른쪽 자식

        public BstNode(int key, T value)
        {
            this.Key = key;
            Value = value;
        }
    }
    
    class BinarySearchTree<T>
    {
        private BstNode<T> _root; 

        //삽입함수
        public void Insert(int key, T value) //{ 16, 14, 78, 31, 90, 5, 15, 1, 10, 87 };
        {
            _root = InsertRec(_root, key, value); 
            //재귀를 의미한다, insert하는데 그에 추가적인 기능을 부여
        }

        private BstNode<T> InsertRec(BstNode<T> node, int key, T value)
        {
            if(node == null)
                return new BstNode<T>(key, value); //일단 처음으로 들어온 key 값을 _root로 설정
            // ㄴ여기까지는 맨 처음 1번

            if(key<node.Key)//들어온 키 값이 node의 키 값보다 작으면 node의 왼쪽값이 InsertRec로 루트는 node.left,그리고 해당 키 값으로 재귀함수가 다시 시작됨
                node.Left = InsertRec(node.Left, key, value); 
        
            if(key>node.Key)//들어온 키 값이 node의 키 값보다 작으면 node의 오른쪽값이 InsertRec로 루트는 node.right,그리고 해당 키 값으로 재귀함수가 다시 시작됨
                node.Right = InsertRec(node.Right, key, value);

            return node;//그리고 해당 노드를 반환한다
        }

        //삭제
        public void Remove(int key)
        {
            _root = RemoveRec(_root, key);
            Console.WriteLine($"{_root.Key}, {key}삭제합니다.");
        }

        private BstNode<T> RemoveRec(BstNode<T> node, int key)
        {
            if (node == null)
                return null; //노드가 null 일 경우 반환한다

            if (key < node.Key) //1. 삭제하려는 키 값이 루트의 키값보다 작을경우, 루트.Left로 다시 재귀함수를 호출한다
            {
                node.Left = RemoveRec(node.Left, key); //1.의 경우, 루트.Left의 키 값과 key 값을 비교해서 끝이 날 때까지 호출
            }
            else if (key > node.Key)
            {
                node.Right = RemoveRec(node.Right, key); //반대.
            }
            else
            {
                //case 1 : leaf인 경우
                if (node.Left == null && node.Right == null) //둘다 leaf인 경우
                    return null;

                //case 2 : 자식 1개인 경우
                if (node.Left == null)
                    return node.Right;
                if (node.Right == null)
                    return node.Left;

                //case 3 : 자식 2개
                BstNode<T> min = FindMin(node.Right);
                node.Key = min.Key;
                node.Right = RemoveRec(node.Right, min.Key);
            }
            return node;
        }

        private BstNode<T> FindMin(BstNode<T> node)
        {
            while(node.Left != null)
            {
                node = node.Left;
            }
            return node;
        }

        //탐색
        public bool Contains(int key)
        {
            var now = _root;//루트값 부터 찾기를 시작한다
            while (now != null)//찾는 노드 값이 null 일 때까지
            {
                if (key == now.Key) return true; //현재 루트의 키 값이 들어온 키 값과 같다면 true 반환 == 찾았다!

                //아니라면
                now = (key < now.Key) ? now.Left : now.Right; //값을 확인해서 작으면 왼쪽, 크면 오른쪽 자식들을 탐색
            }
            return false; //해당 값이 트리에 없는것
        }

        //어떠한 값이 들어있는지 반환하는 함수
        public BstNode<T> Find(int key)
        {
            var now = _root;//루트값 부터 찾기를 시작한다
            while (now != null)//찾는 노드 값이 null 일 때까지
            {
                if (key == now.Key) return now; //현재 루트의 키 값이 들어온 키 값과 같다면 true 반환 == 찾았다!

                //아니라면
                now = (key < now.Key) ? now.Left : now.Right; //값을 확인해서 작으면 왼쪽, 크면 오른쪽 자식들을 탐색
            }
            return null; //해당 값이 트리에 없는것
        }
    }

    internal class _250908
    {
        //0 1 2 3 4 5 6 7 8 9  -> ChangeBinary(List<int> ret, int lo, int hi) -> 4 1 0 2 3 7 5 6 8 9(이진형식으로 들어가도록)
        static List<int> ChangeBinary()
        {
            List<int> result = new List<int>();

            ChangeBinary(result, 0, 9);

            return result;
        }

        //4 1 0 2 3 7 5 6 8 9
        static void ChangeBinary(List<int> ret, int low, int high)
        {
            if (low > high) //0>9
                return;

            int mid = (low + high) / 2; 

            ret.Add(mid); //처음에 4가 들어감
            Console.WriteLine(mid);

            ChangeBinary(ret, low, mid - 1);
            ChangeBinary(ret, mid + 1, high);
            
        }

        //static void Main(string[] args)
        //{
        //    //ChangeBinary();

        //    var bst = new BinarySearchTree<string>();

        //    int[] data = { 16, 14, 78, 31, 90, 5, 15, 1, 10, 87 };
        //    foreach (var x in data)
        //    {
        //        bst.Insert(x, "A");
        //    }
            ////bst.Remove(16);//여기까지 왔을떄 루트가 31이면 정상
            //int[] data2 = { 91,92,93 };
            //foreach (var x in data2)
            //{
            //    bst.Insert(x);
            //}

            //bst.Remove(16);


            //var bst = new BinarySearchTree<int>();


            //foreach(int item in ChangeBinary())
            //{
            //    Console.WriteLine(item);
            //    bst.Insert(item,item);
            //}


        //}
    }
}
