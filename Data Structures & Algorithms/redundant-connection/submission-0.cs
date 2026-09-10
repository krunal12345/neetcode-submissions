public class Solution {
    public int[] FindRedundantConnection(int[][] edges) {
        int n = edges.Length;
        List<int>[] adj = new List<int>[n + 1];
        for (int i = 0; i <= n; i++) adj[i] = new List<int>();

        foreach (var edge in edges) {
            int u = edge[0], v = edge[1];
            adj[u].Add(v);
            adj[v].Add(u);
        }

        bool[] visit = new bool[n + 1];
        HashSet<int> cycle = new HashSet<int>();
        int cycleStart = -1;

        bool Dfs(int node, int par) {
            if (visit[node]) {
                cycleStart = node;
                return true;
            }
            visit[node] = true;
            foreach (int nei in adj[node]) {
                if (nei == par) continue;
                if (Dfs(nei, node)) {
                    if (cycleStart != -1) cycle.Add(node);
                    if (node == cycleStart) {
                        cycleStart = -1;
                    }
                    return true;
                }
            }
            return false;
        }

        Dfs(1, -1);

        for (int i = edges.Length - 1; i >= 0; i--) {
            int u = edges[i][0], v = edges[i][1];
            if (cycle.Contains(u) && cycle.Contains(v)) {
                return new int[] { u, v };
            }
        }
        return new int[0];
    }
}