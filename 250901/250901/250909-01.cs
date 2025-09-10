using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250901
{
    //class Pos
    //{
    //    public Pos(int y, int x) { Y = y; X = x; }

    //    public int Y;
    //    public int X;
    //}

    //class BFSwork
    //{
        
    //    public int PosY { get; set; }
    //    public int PosX { get; set; }

    //    enum Dir
    //    {
    //        Up = 0,
    //        Left = 1,
    //        Down = 2,
    //        Right = 3
    //    }

    //    int _dir = (int)Dir.Up;
    //    List<Pos> _points = new List<Pos>();

    //    int n, m;
    //    int[,] adj;
    //    int[,] visited;

    //    public void BFS(int n, int m)
    //    {
    //        PosY = m; 
    //        PosX = n;

    //        adj = new int[n, m]; //맵의 배열
    //        visited = new int[n, m]; //방문체크?
    //        int[,] distance = new int[n,m];//거리 확인

    //        int[] deltaY = { -1, 0, 1, 0 };
    //        int[] deltaX = { 0, -1, 0, 1 };

    //        bool[,] found = new bool[n, m];
    //        Pos[,] parent = new Pos[n, m];

    //        //Stack<Pos> _points = new Stack<Pos>();

    //        Queue<Pos> queue = new Queue<Pos>();
    //        queue.Enqueue(new Pos(PosY,PosX));
    //        found[n,m] = true;
    //        parent[n,m] = new Pos(n,m);//자기자신을 부모로 설정해줌
    //        distance[n, m] = 0;

    //        while (queue.Count > 0)
    //        {
    //            Pos pos = queue.Dequeue(); //첫 지점을 끄집어내서
    //            int nowY = pos.Y;
    //            int nowX = pos.X; //정수 형태로 만든다

    //            for (int i = 0; i < 4; i++)
    //            {
    //                int nextY = nowY + deltaY[i]; //i가 0일때 위, 1일때 아래,,.뭐 이런식으로 for문이 돌아가면서 모든 방향을 확인?
    //                int nextX = nowX + deltaX[i];

    //                //맵의 크기를 초과하지 않는지
    //                if (nextY < 0 || nextY >= m || nextX < 0 || nextX >= n)
    //                    continue;

    //                //체크 하려는 점이 갈수 있는 점인지
    //                if (adj[nextY, nextX] == 0)
    //                    continue;

    //                //이미 찾았던 점이라면
    //                if (found[nextY, nextX] == true)
    //                    continue;

    //                queue.Enqueue(new Pos(nextY, nextX));
    //                found[nextY, nextX] = true;
    //                parent[nextY, nextX] = new Pos(nowY, nowX);
    //            }
    //        }

    //        int y = m;
    //        int x = n;

    //        while (parent[y, x].Y != y || parent[y, x].X != x) //목적지 좌표부터 하나하나 거슬러 올라간다 시작지점까지 -> 최초지점이 아닐때만 반복임
    //        {
    //            //[0] -> 목적지
    //            //[1] -> 목적지의 부모
    //            //.....
    //            //[마지막인덱스] -> 최초 지점

    //            _points.Add(new Pos(y, x));
    //            Pos pos = parent[y, x];
    //            y = pos.Y;
    //            x = pos.X;
    //        }
    //        _points.Add(new Pos(y, x));

    //        _points.Reverse(); //-> 내부에 들어가 있는 정보들이 뒤집히게 된다
    //                           //[0] -> 최초지점
    //                           //[1] -> 최초지점 다음
    //                           //.....
    //                           //[마지막인덱스] -> 목적 지점

    //    }

    //}
    //internal class _250909_01
    //{
    //    static void Main(string[] args)
    //    {
    //        int[] deltaY = { -1, 0, 1, 0 }; //Y축좌표
    //        int[] deltaX = { 0, -1, 0, 1 }; //X축좌표
    //        int[,] adj = new int[50, 50]; //맵 배열(최대크기 50)
    //        bool[,] visited = new bool[50, 50]; //방문 배열(최대크기가 50이니까)
    //        int m, n, k; //가로m, 세로n, 배추 개수k

    //        int t = int.Parse(Console.ReadLine()); //회차
    //        while (t-- > 0) //회차 돌 때마다 1씩 후위감소연산
    //        {
    //            Array.Clear(adj); //배열 초기화
    //            Array.Clear(visited); //방문 배열 초기화
    //            string[] input = Console.ReadLine().Split(); //2번째 출에 m,n,k 준다고 했으니까 한줄 받기
    //            m = int.Parse(input[0]); //배추밭 가로길이
    //            n = int.Parse(input[1]); //배추밭 세로길이
    //            k = int.Parse(input[2]); //배추의 총 갯수

    //            int x, y; //그 밑에줄부터 배추의 위치 - x,y 좌표

    //            for (int i = 0; i < k; i++) //배추 준다고 한 k개수만큼 포문 돌기
    //            {
    //                string[] delta = Console.ReadLine().Split(); //좌표 x,y주니까 한줄 받아서 띄어쓰기로 분리
    //                x = int.Parse(delta[0]); //배추의 x위치
    //                y = int.Parse(delta[1]); //배추의 y위치
    //                adj[y, x] = 1; //해당좌표에 배추 심기
    //            }

    //            DFS(1);
    //        }

    //        void DFS(int y, int x)//now = 시작점, 입구
    //        {
    //            int count = 0;
    //            //1.어떠한 vertex에 진입을 했다-now 부터 방문 후 방문 체크
    //            Console.WriteLine($"방문 : {adj[y,x]}");
    //            visited[y,x] = true; //방문하고, 방문 체크 visited[now] = true;

    //            //2.now와 연결된 정점들을 하나씩 확인(길 확인), 아직 방문하지 않은 정점을 방문
    //            for (int next = 0; next < adj.GetLength(0); next++)//연결되어있는지 "하나씩"확인
    //            {
    //                for(int i = 0; i<4; i++)
    //                {
    //                    int nextY = y + deltaY[i]; //i가 0일때 위, 1일때 아래,,.뭐 이런식으로 for문이 돌아가면서 모든 방향을 확인?
    //                    int nextX = x + deltaX[i];
    //                    //맵의 크기를 초과하지 않는지
    //                    if (nextY < 0 || nextY >= n || nextX < 0 || nextX >= m)
    //                        continue;

    //                    //체크 하려는 점이 갈수 있는 점인지
    //                    if (adj[nextY, nextX] == 0)
    //                        continue;

    //                    //이미 찾았던 점이라면
    //                    if (visited[nextY, nextX] == true)
    //                        continue;

    //                    visited[nextY, nextX] = true;
    //                }

    //                if (adj[start, next] == 0) //0이라는것은 해당 길이 없다는것으로 continue
    //                    continue;

    //                if (visited[start,next] == true) //이미 방문했으므로 continue
    //                    continue;

    //                count++;

    //                //3.여기서 연결되어있는지 확인, 방문확인을 했으므로 확인 자체는 끝, 그리고 방문하지 않은 정점을 방문해야 하므로
    //                DFS(next); //--> 함으로써 now는 1로 변경이 된다..
    //            }

    //            for (int now = 0; now < adj.GetLength(0); now++)
    //            {
    //                for(int next = 0; next < adj.GetLength(1); next++)
    //                {
    //                    if (!visited[now,next])
    //                    {
    //                        DFS(now);
    //                    } 
    //                }
    //            }
    //        }
    //    }

        
    //}
}

namespace BFSDFS
{
    internal class Program
    {
        static bool[,] visited = new bool[50, 50]; // 방문 배열 (최대크기가 50이니까)
        static int[] deltaY = { -1, 0, 1, 0 };  // Y 축 좌표
        static int[] deltaX = { 0, -1, 0, 1 };  // X 축 좌표
        static int m, n, k;  // 가로 m, 세로 n, 배추 개수 k
        static int[,] adj = new int[50, 50];    // 맵 배열 (최대크기가 50이라 했음)

        static void DFS(int y, int x)
        {
            visited[y, x] = true;
            for (int i = 0; i < 4; i++)
            {
                int newY = y + deltaY[i];
                int newX = x + deltaX[i];

                if (newY < 0 || newY >= n || newX < 0 || newX >= m)
                    continue;
                if (adj[newY, newX] == 0)
                    continue;
                if (visited[newY, newX] == true)
                    continue;
                DFS(newY, newX);
            }
        }
        void BFS()
        {
            int[] deltaY = { -1, 0, 1, 0 }; // Y축 이동 좌표 : 위, 왼쪽, 아래, 오른쪽
            int[] deltaX = { 0, -1, 0, 1 }; // X축 이동 좌표 : 위, 왼쪽, 아래, 오른쪽
            //      [-1 ] 
            // [-1 ]     [ 1 ] 
            //      [ 1 ]
            int n, m; // 입력받을 n, m 
            int[,] adj; // 맵을 만들 인접행렬
            int[,] visited; // 방문

            string[] input = Console.ReadLine().Split(); // 한줄 통쨰로 입력받아 띄어쓰기로 분할해 배열에 전달
            n = int.Parse(input[0]); // 첫번째 받은 숫자
            m = int.Parse(input[1]); // 두번째 받은 숫자

            adj = new int[n, m]; // 받은 숫자만큼 맵 배열 크기 고정
            visited = new int[n, m]; // 받은 숫자만큼 방문 배열 크기 고정

            // 배열 넘겨준다고 했으니 입력 받기
            for (int i = 0; i < n; i++)
            {
                // 한줄 한줄 들어오니까 한줄 일단 입력 받기 ex) 101111
                string line = Console.ReadLine();
                for (int j = 0; j < m; j++)
                {
                    // 입력받은 한줄을 한칸씩 짤라서 맵 배열에 하나씩 넣어주기
                    adj[i, j] = line[j] - '0'; // <-- 여기 나온 '0'은 숫자 48 
                                               // 즉, line[j] 에서 나온 문자 또한 아스키코드 48 (1은 49)
                                               // 아스키코드 뺄샘을 통해서 숫자형식으로 변환
                }
            }

            #region
            Queue<(int, int)> q = new Queue<(int, int)>();
            visited[0, 0] = 1;
            q.Enqueue((0, 0));
            while (q.Count > 0)
            {
                (int y, int x) = q.Dequeue();
                for (int i = 0; i < 4; i++)
                {
                    int newY = y + deltaY[i];
                    int newX = x + deltaX[i];

                    if (newY < 0 || newY >= n || newX < 0 || newX >= m)
                        continue;

                    if (adj[newY, newX] == 0)
                        continue;

                    if (visited[newY, newX] > 0)
                        continue;

                    visited[newY, newX] = visited[y, x] + 1;
                    q.Enqueue((newY, newX));
                }
            }

            Console.WriteLine(visited[n - 1, m - 1]);
            #endregion

        }

        //static void Main(string[] args)
        //{
        //    int t = int.Parse(Console.ReadLine()); // 회차
        //    while (t-- > 0) // 회차 돌때마다 1씩 후위감소연산 
        //    {
        //        int ret = 0;

        //        Array.Clear(adj); // 회차라는건 배열을 그대로 쓴다는거니까 배열 초기화
        //        Array.Clear(visited); // 회차라는건 배열을 그대로 쓴다는거니까 배열 초기화
        //        string[] input = Console.ReadLine().Split(); // 2번째 줄에 m, n, k 준다고 했으니까 한줄 받기
        //        m = int.Parse(input[0]); // 한줄 받아서 분리
        //        n = int.Parse(input[1]); // 한줄 받아서 분리
        //        k = int.Parse(input[2]); // 한줄 받아서 분리

        //        int x, y; // 그 밑에줄부터 배추에 대한 x, y 좌표 준다고 했으니까 

        //        for (int i = 0; i < k; i++) // 배추 준다고 한 k 개수만큼 포문 돌기
        //        {
        //            string[] delta = Console.ReadLine().Split(); // 좌표 x y 주니까 한줄 받아서 띄어쓰기로 분리
        //            x = int.Parse(delta[0]); // 한줄 받아서 분리
        //            y = int.Parse(delta[1]); // 한줄 받아서 분리
        //            adj[y, x] = 1; // 배추 있는 좌표 받았으니 배열에 해당 좌표에 배추 심기
        //        }

        //        for (int i = 0; i < n; i++)
        //        {
        //            for (int j = 0; j < m; j++)
        //            {
        //                if (adj[i, j] == 0)
        //                    continue;
        //                if (visited[i, j] == true)
        //                    continue;
        //                DFS(i, j);
        //                ret++;
        //            }
        //        }

        //        Console.WriteLine(ret);
        //    }
        //}
    }
}
