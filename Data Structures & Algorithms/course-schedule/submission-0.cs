public class Solution
{
    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        var graph = new List<int>[numCourses];

        for (int i = 0; i < numCourses; i++)
            graph[i] = new List<int>();

        // [a, b] => a depends on b
        foreach (var p in prerequisites)
        {
            int course = p[0];
            int prerequisite = p[1];

            graph[course].Add(prerequisite);
        }

        var visiting = new HashSet<int>();
        var visited = new HashSet<int>();

        for (int course = 0; course < numCourses; course++)
        {
            if (!DFS(course, graph, visiting, visited))
                return false;
        }

        return true;
    }

    private bool DFS(
        int course,
        List<int>[] graph,
        HashSet<int> visiting,
        HashSet<int> visited)
    {
        // Found the same node in current DFS path => cycle
        if (visiting.Contains(course))
            return false;

        // Already completely checked => safe
        if (visited.Contains(course))
            return true;

        visiting.Add(course);

        foreach (int prerequisite in graph[course])
        {
            if (!DFS(prerequisite, graph, visiting, visited))
                return false;
        }

        // DFS path for this course is complete
        visiting.Remove(course);
        visited.Add(course);

        return true;
    }
}