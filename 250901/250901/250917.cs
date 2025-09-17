using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace tree
{
    internal class _250917
    {
        //트리의 최상단 - 루트(오직 한개)
        //재귀함수를 사용하면 구현에 용이

    }

    class TreeNode<T>
    {
        public T Data;
        public List<TreeNode<T>> Children { get; set; } = new List<TreeNode<T>>();
    }

    class Program
    {
        static TreeNode<string> MakeTree()
        {
            TreeNode<string> root = new TreeNode<string>() { Data = "A" };
            {
                TreeNode<string> nodeB = new TreeNode<string>() { Data = "B" };
                {
                    TreeNode<string> nodeD = new TreeNode<string>() { Data = "D" };
                    {
                        TreeNode<string> nodeH = new TreeNode<string>() { Data = "H" };
                        TreeNode<string> nodeI = new TreeNode<string>() { Data = "I" };

                        nodeD.Children.Add(nodeH);
                        nodeD.Children.Add(nodeI);
                    }
                    TreeNode<string> nodeE = new TreeNode<string>() { Data = "E" };

                    nodeB.Children.Add(nodeD);
                    nodeB.Children.Add(nodeE);
                }
                TreeNode<string> nodeC = new TreeNode<string>() { Data = "C" };
                {
                    TreeNode<string> nodeF = new TreeNode<string>() { Data = "F" };
                    TreeNode<string> nodeG = new TreeNode<string>() { Data = "G" };

                    nodeC.Children.Add(nodeF);
                    nodeC.Children.Add(nodeG);
                }

                root.Children.Add(nodeB);
                root.Children.Add(nodeC);
            }

            return root;
        }

        static void PrintTree(TreeNode<string> root)
        {
            Console.WriteLine(root.Data);
            foreach(var item in root.Children)
            {
                PrintTree(item);
            }
        }

        //높이 구하기
        static int GetHeight(TreeNode<string> root)
        {
            int height = 0;
            foreach(var item in root.Children)
            {
                height++;
                GetHeight(item);
            }
            return height+1;
        }

        static void Main(string[] args)
        {
            var root = MakeTree();
            PrintTree(root);
            Console.WriteLine();
            Console.WriteLine(GetHeight(root));
        }
    }
}
