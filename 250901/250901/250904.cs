using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250901
{
    //다익스트라(Dijkstra) - 가중치 계산을 포함한 최단 경로 찾기
    //-> BFS를 알면 얘도 이해하기 쉽다 -> AStar

    //BFS 단점
    //모든 경로의 이동이 동일한 조건일 때, 즉 가중치가 없는 그래프에서만 사용이 가능하다

    class Graph
    {
        int[,] adj = new int[8, 8]
        {  // 0  1  2  3  4  5  6  7
            {-1,10,-1,18,-1,-1,-1,-1},
            {10,-1,05,06,-1,-1,-1,-1},
            {-1,05,-1,-1,-1,-1,-1,-1},
            {18,06,-1,-1,13,-1,-1,-1},
            {-1,-1,-1,13,-1,14,08,-1},
            {-1,-1,-1,-1,14,-1,-1,17},
            {-1,-1,-1,-1,08,-1,-1,26},
            {-1,-1,-1,-1,-1,17,26,-1}
        };

        public void Dijkstra(int start)
        {

            bool[] visited = new bool[8]; //실제로 방문 했는지에 대한 여부
            int[] distance = new int[8]; //정점으로 가는 가장 짧은 가중치를 "기록"하기 위한
            Array.Fill(distance, Int32.MaxValue); //일단 이상한 값으로 초기화를 해줘서 헷갈림 방지
            int[] parent = new int[8];
            
            distance[start] = 0; //시작점은 거리가 없으니까 0
            parent[start] = start;

            //원래라면 Queue를 사용하지만 가중치가 있으므로 다른 방식 채택
            while (true)
            {
                //제일 좋은 후보 찾기(최단 거리 후보)
                //가장 유력한 후보의 거리 번호를 저장
                int closest = Int32.MaxValue; 
                int now = -1; 

                //각 정점을 순회하면서 순회하는 정점이 후보가 맞는지(연결이 되어있는지) 확인
                for(int i = 0; i < 8; i++)
                {
                    //조건 1. 이미 방문한 정점은 skip
                    if (visited[i] == true) continue;

                    //조건 2. 아직 발견(예약) 된 적이 없거나, 기존 후보보다 멀면 스킵한다 -> 기존 후보를 저장할 공간이 필요하다
                    if (distance[i] == Int32.MaxValue || distance[i] >= closest) continue; 

                    //조건 3. 발견한 후보 중 가장 좋은 후보를 찾음, 정보를 갱신
                    closest = distance[i]; //처음 0 이 들어왔을때 -> distance[i] = 0이고 따라서 closest도 0이다
                    now = i;
                }
                if (now == -1) break; //위 for문에서 continue 를 뚫은 적이 없다(now가 초기에 넣어준 값 그대로이다 -> 접근하지 못했다(후보군이 없다) 면 끝냄
                
                //제일 좋은 후보로 채택해줌
                //방문했다?
                visited[now] = true;

                //방문한 정점의 인접점을 확인하고, 최단거리를 갱신해준다
                for(int next = 0; next<8; next++)
                {
                    //연결이 되어있지 않은 정점은 스킵
                    if (adj[now,next] ==-1) continue;

                    //이미 넥스트를 방문했었다? 그럼 스킵
                    if (visited[next] == true) continue;
                    

                    //새로 조사된 인접 정점의 최단거리 계산(0번 기준으로 0번까지의 최단거리가 distance[0]이 될텐데 그걸 다른 정점과 확인하게 된다?
                    int nextDist = distance[now] + adj[now,next]; 
                    //위의 인접 정점의 최단거리를 갱신
                    if (nextDist < distance[next])//정점의 실제 거리보다 nextDist 가 작다면?
                    {
                        //nextDist가 최단거리가 된다는 뜻이므로, distance[next]를 최단거리로 갱신해준다
                        distance[next] = nextDist;
                        parent[next] = now;
                    }
                }
            }
        }
    }

    //internal class _250904
    //{
    //    static void Main(string[] args)
    //    {
    //        Graph graph = new Graph();
    //        graph.Dijkstra(0);
    //    }
    //}
}
