public class Solution
{
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

    public int NumIslands(char[][] grid)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;

        DSU dsu = new DSU(rows * cols);

        // Create one set for every '1'
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (grid[r][c] == '1')
                {
                    int index = r * cols + c;
                    dsu.MakeSet(index);
                }
            }
        }

        // Merge connected 1s
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (grid[r][c] != '1')
                    continue;

                int current = r * cols + c;

                // Right
                if (c + 1 < cols && grid[r][c + 1] == '1')
                {
                    int right = r * cols + (c + 1);
                    dsu.Union(current, right);
                }

                // Down
                if (r + 1 < rows && grid[r + 1][c] == '1')
                {
                    int down = (r + 1) * cols + c;
                    dsu.Union(current, down);
                }
            }
        }

        return dsu.Count;
    }
}