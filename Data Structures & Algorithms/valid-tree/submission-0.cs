public class Solution
{
    public bool ValidTree(int n, int[][] edges)
    {
        // A valid tree with n nodes must have exactly n - 1 edges
        if (edges.Length != n - 1)
            return false;

        int[] parent = new int[n];
        int[] rank = new int[n];

        for (int i = 0; i < n; i++)
            parent[i] = i;

        foreach (var edge in edges)
        {
            int a = edge[0];
            int b = edge[1];

            int rootA = Find(a, parent);
            int rootB = Find(b, parent);

            // Already connected => adding this edge creates a cycle
            if (rootA == rootB)
                return false;

            Union(rootA, rootB, parent, rank);
        }

        return true;
    }

    private int Find(int node, int[] parent)
    {
        if (parent[node] != node)
            parent[node] = Find(parent[node], parent);

        return parent[node];
    }

    private void Union(int rootA, int rootB, int[] parent, int[] rank)
    {
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
    }
}