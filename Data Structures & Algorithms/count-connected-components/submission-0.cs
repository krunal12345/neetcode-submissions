public class Solution {
    public int CountComponents(int n, int[][] edges) {
       DSU dsu = new DSU(n);

        // Initially every node is its own component
        for (int i = 0; i < n; i++)
        {
            dsu.MakeSet(i);
        }

        // Merge connected components
        foreach (var edge in edges)
        {
            dsu.Union(edge[0], edge[1]);
        }

        return dsu.Count;
    }
    
    class DSU
    {
        int[] parent;
        int[] rank;
        public int Count;

        public DSU(int size)
        {
            parent = new int[size];
            rank = new int[size];

            Array.Fill(parent, -1);
        }

        public void MakeSet(int x)
        {
            parent[x] = x;
            Count++;
        }

        public int Find(int x)
        {
            if (parent[x] != x)
            {
                parent[x] = Find(parent[x]);
            }

            return parent[x];
        }

        public void Union(int a, int b)
        {
            int rootA = Find(a);
            int rootB = Find(b);

            if (rootA == rootB)
                return;

            if (rank[rootA] < rank[rootB])
            {
                parent[rootA] = rootB;
            }
            else if (rank[rootA] > rank[rootB])
            {
                parent[rootB] = rootA;
            }
            else
            {
                parent[rootB] = rootA;
                rank[rootA]++;
            }

            Count--;
        }
    }

}
