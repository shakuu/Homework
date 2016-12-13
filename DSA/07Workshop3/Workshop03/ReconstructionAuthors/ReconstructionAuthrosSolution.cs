namespace Airport
{
    using System;
    using System.Collections.Generic;

    class ReconstructionAuthrosSolution
    {
        class Edge : IComparable<Edge>
        {
            public int a;
            public int b;
            public int cost;

            public Edge(int a, int b, int cost)
            {
                this.a = a;
                this.b = b;
                this.cost = cost;
            }

            public int CompareTo(Edge e)
            {
                return cost - e.cost;
            }
        }

        static int GetValue(char c)
        {
            if (c >= 'A' && c <= 'Z')
                return c - 'A';
            return c - 'a' + 26;
        }

        static int GetCost(List<string> path, List<string> build, List<string> destroy)
        {
            int N = path.Count, massiveCost = 0, mstCost = 0;
            // get the cost of each edge + destroy all the existing edges
            List<Edge> edges = new List<Edge>();

            for (int i = 0; i < N; ++i)
                for (int j = i + 1; j < N; ++j)
                {
                    if (path[i][j] == '0')
                        edges.Add(new Edge(i, j, GetValue(build[i][j])));
                    else
                    {
                        int val = GetValue(destroy[i][j]);
                        edges.Add(new Edge(i, j, -val));
                        massiveCost += val;
                    }
                }
            // solve the MST on the graph, using Kruskal's algorithm
            edges.Sort();

            int[] color = new int[N];
            for (int i = 0; i < N; ++i)
                color[i] = i;

            for (int i = 0; i < edges.Count; ++i)
            {
                Edge e = edges[i];
                // vertices of the edge are not in the same component
                if (color[e.a] != color[e.b])
                {
                    mstCost += e.cost;
                    // recolor the component
                    int oldColor = color[e.b];
                    for (int j = 0; j < N; ++j)
                        if (color[j] == oldColor)
                            color[j] = color[e.a];
                }
            }
            return massiveCost + mstCost;
        }

        static void Main()
        {
            int N = int.Parse(Console.ReadLine());

            List<string> paths = new List<string>();
            List<string> builds = new List<string>();
            List<string> destroy = new List<string>();

            for (int i = 0; i < N; i++)
            {
                paths.Add(Console.ReadLine());
            }

            for (int i = 0; i < N; i++)
            {
                builds.Add(Console.ReadLine());
            }

            for (int i = 0; i < N; i++)
            {
                destroy.Add(Console.ReadLine());
            }

            Console.WriteLine(GetCost(paths, builds, destroy));
        }
    }
}
