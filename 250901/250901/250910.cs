using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250901
{
    class List<T>
    {
        //현재 가지고있는 배열의 인덱스 값
        public int IndexValue { get { return list.Length; } }
        public int IndexCount = 0;
        //현재까지 사용한 인덱스 갯수
        
        T[] list = new T[1];

        public void Add(T t)
        {
            if(IndexCount >= IndexValue)
            {
                T[] newlist = new T[IndexValue *2];
                for (int i = 0; i < IndexValue; i++)
                {
                    newlist[i] = list[i];   
                }
                list = newlist;
            }
            list[IndexCount] = t;//list 0 에다 t를 넣고
            Console.WriteLine($"넣은 값 : {list[IndexCount]} / 현재 인덱스 갯수 : {IndexValue}");
            IndexCount++; //위에서 넣었으니 다음 indexCOunt는 1
        }

        public void Remove(int t)
        {
            Console.WriteLine($"삭제 전 : {list[t]}");
            for(int i = t; i< IndexValue-1; i++) //6까지일때 i는 4까지만될수있다 2-3,3-4,4-5
            {
                list[i] = list[i + 1];
            }
            Console.WriteLine($"삭제 후 : {list[t]}");
            IndexCount--;
        }
    }

    class LinkedList
    {
        public Node Head = null;
        public Node Tail = null;

        public void AddList(int a)
        {
            Node node = new Node();
            node.Value = a;

            if(Head == null)
            {
                Head = node;
                Tail = node;
                Head.nextNode = node;
                Tail.PreNode = node;
            }
            if(Head != null) //헤드가 있다면? 계속 꼬리 생성이 되는거니까?
            {
                Tail.nextNode = node;
                node.PreNode = Tail;
                Tail = node;
            }
            //if(Tail.nextNode == null)
            //{
            //    Tail.nextNode = node;
            //}
            Console.WriteLine($"새로들어온 노드값 : {node.Value} / 이전노드값 : {node.PreNode.Value}");
        }

        public void RemoveAt(Node node)
        {
            Console.Write($"삭제하려는 노드값 : {node.Value}");

            if (Head == node)
            {
                (node.nextNode).PreNode = null;
                Head = node.nextNode;
                node.PreNode = null;
            }
            if(Tail == node)
            {
                (node.PreNode).nextNode = null;
                Tail = node.PreNode;
            }
            if(node!=Head && node !=Tail)
            {
                node.PreNode = (node.nextNode).PreNode;
                node.nextNode = (node.PreNode).nextNode;
            }

            Console.Write($"삭제하려는 노드값 : {node.Value}");

        }
    }

    class Node
    {
        public Node nextNode;
        public Node PreNode;
        public int Value;
    }

    internal class _250910
    {
        //static void Main(string[] args)
        //{
        //    //List<int> list = new List<int>();
        //    //list.Add(1);
        //    //list.Add(2);
        //    //list.Add(3);
        //    //list.Add(4);

        //    //list.Remove(0);

        //    LinkedList list = new LinkedList();
        //    Node node = list.AddList(3);
        //    list.AddList(0);
        //    list.AddList(1);
        //    list.AddList(2);
        //    list.AddList(3);
        //    list.AddList(4);

        //    list.RemoveAt(node);
        //}
    }
}
