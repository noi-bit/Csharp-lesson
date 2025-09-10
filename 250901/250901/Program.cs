namespace _250901
{
    //알고리즘 DFS / BFS

    //DFS = 깊이 우선 탐색(Depth first Search)
        //DFS 는 그래프를 탐색할 때 쓰는 알고리즘
        //어떤 vertex부터 시작해서 인접한 vertex들을 재귀적으로 방문
        //방문한 vertex는 다시 방문하지 않습니다
        //각 분기마다 가장 단계적으로 깊은 vertex까지 탐색한다
        //*DFS 핵심 : 내가 했던 일을(함수) 내 다음에게 떠넘긴다*
        //  ㄴ> DFS 역할 : 끊긴 길 찾기

    //BFS = 너비 우선 탐색(Breadth first Search)
        //기억을 한다(방문한 vertex들을) 
        //  (0에서 탐색 가능한 1과 3을 기억 하고, 1or3에 방문, 그리고 1에 2가 붙어있다면 2를 기억하고 3을 방문하여 3의 자식 vertex가 있는지 기억하고..어쩌구)
        //  ㄴ> Queue 자료형식으로 구현할 수 있다, Queue를 통해서 값을 넣고 제일 오래 기다린 vertex를 꺼내어 쓴다
        //*BFS 핵심 : BFS는 경로를 탐색해서 정보를 기록한다!!!!*(최단거리를 찾으려면 해당 코드를 작성해야함!=> 거꾸로 역계산을 해서 부모길이가 제일 짧은? 걸 구하면 됨)
        //  ㄴ> BFS 역할 : 그래프 경로를 탐색해서 정보 기록

    class Graphs
    {
        int[,] adj = new int[6, 6]
        {
            {0 ,1 ,0 ,1 ,0 ,0 },
            {1 ,0 ,1 ,1 ,0 ,0 },
            {0 ,1 ,0 ,0 ,0 ,0 },
            {1 ,1 ,0 ,0 ,1 ,0 },
            {0 ,0 ,0 ,1 ,0 ,1 },
            {0 ,0 ,0 ,0 ,1 ,0 },
        };

        bool[] found = new bool[6]; 
        int[] parent = new int[6]; //parant[0] => 0의 정점의 부모가 누구야? ,parant[1] => 1의 정점의 부모가 누구야?
        int[] distance = new int[6]; //distance[0] => 해당 정점까지 걸린 길 이 몇개야? 

        public void DFS(int now)//now = 시작점, 입구
        {
            //1.어떠한 vertex에 진입을 했다-now 부터 방문 후 방문 체크
            Console.WriteLine($"방문 : {now}");
            found[now] = true; //방문하고, 방문 체크 visited[now] = true;

            //2.now와 연결된 정점들을 하나씩 확인(길 확인), 아직 방문하지 않은 정점을 방문
            for(int next = 0; next < adj.GetLength(0); next ++)//연결되어있는지 "하나씩"확인
            {
                if (adj[now, next] == 0) //0이라는것은 해당 길이 없다는것으로 continue
                    continue;
                
                if (found[next]==true) //이미 방문했으므로 continue
                    continue;

                //3.여기서 연결되어있는지 확인, 방문확인을 했으므로 확인 자체는 끝, 그리고 방문하지 않은 정점을 방문해야 하므로
                DFS(next); //--> 함으로써 now는 1로 변경이 된다..
            }
        }
        public void SearchAll(int now)
        {
            DFS(now);
            Console.WriteLine("끊어진 루트 탐색");
            for (int i = 0; i < found.Length; i++)
                if (!found[i])
                {
                    DFS(i);
                }
        }
        public void SearchAll2()//사람들
        {
            for(int now = 0;  now < adj.GetLength(0); now ++)
            {
                if(!found[now])
                {
                    DFS(now);
                }
            }
        }

        public void BFS(int start)
        {
            found = new bool[6]; //방문목록

            Queue<int> queue = new Queue<int>(); //예약목록

            //1.예약목록에 예약하기
            //예약목록에 시작지점을 등록한다
            queue.Enqueue(start);

            //start 방문 처리
            found[start] = true; //스타트 지점 방문
            parent[start] = start; //본인의 부모는 본인
            distance[start] = 0; //본인끼리니까 거리는 0

            while (queue.Count > 0)
            {
                //2.예약목록에서 예약을 꺼내와서
                int now = queue.Dequeue(); //맨 처음이라면 위에 Enqueue한 0을 꺼내옴

                Console.WriteLine($"BFS - {now}를 방문했어~");

                //아직 예약 안한 vertex들 전부 예약하기
                for (int next = 0; next < 6; next++)
                {
                    //연결이 안되어있으면 넘기고(continue)
                    if (adj[now, next] == 0) //맨 처음이면 {{0,0}이므로 continue
                        continue;

                    //연결이 되어있으면 예약이 되어있는지 확인,
                    //예약이 되어있으면 넘긴다
                    if (found[next] == true)
                        continue;

                    //예약하기
                    queue.Enqueue(next);

                    //예약한놈 찾은놈으로 설정
                    found[next] = true;

                    //찾은놈의 부모는 now
                    parent[next] = now;

                    //찾은놈의 거리는 부모 + 1을 해주면 됨
                        //가중치가 있다면 그 해당 가중치 배열의 index를 추가하면 되겠지?
                    distance[next] = distance[now] + 1;
                    Console.WriteLine(distance[next]);
                }
            }
        }
    }


    class Program
    {
        //static void Main(string[] args)
        //{
        //    Graph graph = new Graph();
        //    //graph.DFS(0);//시작 지점을 0으로 잡아줌
        //    graph.DFS(0);
            
        //    Console.WriteLine();
        //    graph.BFS(0);
        //}
    }
}
