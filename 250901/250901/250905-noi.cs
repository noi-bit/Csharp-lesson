using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250901
{
    internal class _250905_noi
    {
        //트리 - 계층 구조
        //부모에서 자식 쪽으로 한 방향으로 흐른다 - 단방향으로 뻗는다(양방향X), 형제끼리 연결X
        //ㄴ> 위에서 아래로 흐름
        //트리는 단방향 그래프와 유사하다..?
        //트리에서의 Vertex는 Node라고 한다
        //선 이름은 Edge

        //최상단 Node : Root
        //최하단 Node : Leaf
        //한 부모와 자식의 관계 -> 서브트리
        //ㄴ> 서브트리는 트리구조 그 자체와 유사하다 -> 그래서 재귀적인 속성을 가지고 있다

        //깊이 : 특정 노드 사이끼리의 "깊이"를 묘사할때 사용 -> 엣지의 갯수
        //높이 : 트리의 전체 높이

        //그래프는 정적인 상황에서 사용(데이터들의 변화가 없을때)
        //트리는 데이터들이 유동적으로 변화할때 이에 대응하기 위해 사용한다
        // ㄴ>트리는 현실 세계에서 동적으로 변하는 데이터를 다루기위한 자료구조다
    }

    class TreeNode<T>
    {
        //노드를 의미
        public T Data { get; set; } // 루트 A
        public List<TreeNode<T>> Children { get; set; } = new List<TreeNode<T>>();

    }
    
    class Program0905
    {
        static TreeNode<string> MakeTree()
        {
            TreeNode<string> root = new TreeNode<string>() {Data = "A" };
            {
                TreeNode<string> nodeB = new TreeNode<string>() { Data = "B" };
                {
                    TreeNode<string> nodeD = new TreeNode<string>() { Data = "D" };
                    {
                        nodeD.Children.Add(new TreeNode<string> { Data = "H" }); //리프에는 노드값이 안주어지는건가?
                        nodeD.Children.Add(new TreeNode<string> { Data = "I" });
                    }
                }
                TreeNode<string> nodeC = new TreeNode<string>() { Data = "C" };
                {
                    nodeC.Children.Add(new TreeNode<string> { Data = "F" });
                    nodeC.Children.Add(new TreeNode<string> { Data = "G" });
                }
            }
            return root;
        }

        //static void Print(TreeNode<string> root)
        //{
        //    Console.WriteLine(root.Data);

        //    foreach(var child in root.Children)
        //    {
        //        Print(child);
        //    }
        //}

        //static int GetHeight(TreeNode<string> root)
        //{
        //    int height = 0;

        //    foreach(var child in root.Children)
        //    {
        //        int newheight = GetHeight(child) + 1;
        //        height = Math.Max(height, newheight);
        //        //if(height<newheight))
        //        //   height=newheight;
        //    }

        //    return height;
        //}

        //static void Main(string[] args)
        //{
        //    TreeNode<string> root = MakeTree();
        //    Print(root);
        //    Console.WriteLine(GetHeight(root));
        //}
    }
}
