using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BFS
{
    class Graph
    {
        int[] deltaY = { -1, 0, 1, 0 };
        int[] deltaX = { 0, -1, 0, 1 };

        int[,] adj = new int[,]
        {
            {0,1,0,1,0,0 },
            {1,0,1,1,0,0 },
            {0,1,0,0,0,0 },
            {1,1,0,0,1,0 },
            {0,0,0,1,0,1 },
            {0,0,0,0,1,0 },
        };
        //0,0에서 목적지까지 가는데 필요한 엣지가 몇개냐? -parent

        // 1. 방문 목록 
        public bool[] visited = new bool[6];
        public int[] distance = new int[6];
        public void BFS(int start)
        {
            //2. 예약 목록
            Queue<int> queue = new Queue<int>();

            //3. 예약 목록에 예약한다
            queue.Enqueue(start);

            //4. 방문 처리
            visited[start] = true;

            //엣지를 세기 위해
            distance[start] = 0;

            //5. 예약목록에서 예약을 꺼내어 연결되어있고, 방문 안한 예약되어있는 정점 방문
            while (queue.Count > 0) //queue가 비어있으면 끝
            {
                int now = queue.Dequeue();
                Console.WriteLine($"방문했어 {now}");
                Console.WriteLine($"단계 {distance[now]}");

                for (int next = 0; next < adj.GetLength(0); next++)
                {
                    //연결이 되어있는지? -> now는 하나로 고정. 0이면 0,0/0,1/0,2/..이렇게 확인
                    if (adj[now, next] == 0)
                        continue;
                    //방문이 되어있는지/
                    if (visited[next] == true)
                        continue;
                    //둘다 빠져나왔으면 예약 해주기
                    queue.Enqueue(next);
                    visited[next] = true;
                    distance[next] = distance[now] + 1;
                }
            }
            Console.WriteLine();
            Console.WriteLine(distance[adj.GetLength(0)-1]);
        }
        //static void Main(string[] args)
        //{
        //    Graph graph = new Graph();
        //    graph.BFS(0);
        //}
    }
    class Baekjun
    {
        //static void Main(string[] args)
        //{
        //    string[] _size = Console.ReadLine().Split(); //미로의 사이즈
        //    int x = int.Parse(_size[0]);//가로
        //    int y = int.Parse(_size[1]);//세로

        //    int[,] maps = new int[x, y];
        //    for(int i = 0; i< x; i++)
        //    {
        //        string line = Console.ReadLine();
        //        for(int j = 0;  j < y; j++)
        //        {
        //            maps[i, j] = line[j] - '0';
        //        }
        //    }

        //    int[,] visited = new int[x,y];
        //    //int[,] distance = new int[x, y];
            
        //    //  현재위치에서 위 아래 오른쪽 왼쪽
        //    int[] goY =  { -1,1,0,0 };
        //    int[] goX =  { 0,0,1,-1 };


            
        //    Queue<(int,int)> queue = new Queue<(int,int)>();
        //    visited[0,0] = 1;
        //    queue.Enqueue((0,0));

        //    while(queue.Count > 0)
        //    {
        //        (int n, int m) = queue.Dequeue();

        //        //for(int next = 0; next < y; next++)
        //        //{
        //            //if (maps[n, next] == 0) continue;
        //            //if (visited[n, next] == true) continue;

        //        for (int i = 0; i < 4;  i++)
        //        {
        //            int NextY = n + goY[i];
        //            int NextX = m + goX[i];

        //            if (NextY < 0 || NextY >= x || NextX < 0 || NextX >= y) continue;
        //            if (maps[NextY, NextX] == 0) continue;
        //            if (visited[NextY, NextX] >0) continue;

        //            //예약
        //            queue.Enqueue((NextY, NextX));
        //            //방문처리, 거리
        //            visited[NextY, NextX] = visited[n, m]+1;
        //            //distance[NextY, NextX] = distance[start,start2] +1;
        //        }
        //    }
        //    Console.WriteLine($"방문한 횟수 {visited[x-1,y-1]}");
        //}
    }
    class Dijkstra
    {
        //static void Main(string[] args)
        //{
        //    Dijkstra graph = new Dijkstra();
        //    graph.Dijikstra(0);
        //}

        int[,] map = new int[,]
        {
            {-1,10,-1,18,-1,-1,-1,-1},
            {10,-1,05,06,-1,-1,-1,-1},
            {-1,05,-1,-1,-1,-1,-1,-1},
            {18,06,-1,-1,13,-1,-1,-1},
            {-1,-1,-1,13,-1,14,08,-1},
            {-1,-1,-1,-1,14,-1,-1,17},
            {-1,-1,-1,-1,08,-1,-1,26},
            {-1,-1,-1,-1,-1,17,26,-1}
        };

        bool[] visited = new bool[8];
        int[] distance = new int[8];
        int[] parent = new int[8];

        public void Dijikstra(int start)
        {
            Array.Fill(distance, int.MaxValue);
            distance[start] = 0; //해당 인덱스 정점까지의 가장 짧은 거리값이 담김
            parent[start] = 0;

            while (true)
            {
                //제일 좋은 후보 찾기(최단 거리 후보)

                //가장 유력한 후보의 거리와 번호 저장
                int closet = Int32.MaxValue;
                int now = -1;

                for (int i = 0; i < 8/*노드 갯수*/; i++)
                {
                    //이미 방문한 정점은 스킵
                    if (visited[i] == true) continue;

                    //아직 발견된 적이 없거나, 기존 후보보다 멀면 스킵
                    if (distance[i] == int.MaxValue || distance[i] >= closet) continue;

                    //발견한 후보 중 가장 좋은 후보를 "찾음", 정보를 "갱신"(8까지 돌면서 조건에 맞으면 갱신해줌)
                    closet = distance[i];
                    now = i; //<정점의 위치
                }
                if (now == -1) break; //-1이라는건 더이상 예약된 후보가 없다는 뜻

                //제일 좋은 후보 방문
                visited[now] = true;

                //방문한 정점의 인접점을 확인해서 최단거리를 갱신
                for (int next = 0; next < 8; next++)
                {
                    //연결이 되어있지 않으면 스킵
                    if (map[now, next] == -1)
                        continue;
                    //이미 방문한 정점도 스킵
                    if (visited[next] == true)
                        continue;

                    //새로 조사된 인접 정점의 최단 거리 계산
                    int nextDist = distance[now] + map[now, next];
                    //위의 인접 정점의 최단거리를 갱신
                    if (nextDist < distance[next])
                    {
                        distance[next] = nextDist;
                        parent[next] = now;
                    }
                }
            }
        }
    }

}

