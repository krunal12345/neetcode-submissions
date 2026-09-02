public class Solution
{
    public int[] FindOrder(int numCourses, int[][] prerequisites)
    {
        var graph = new List<int>[numCourses];
        var indegree = new int[numCourses];

        for (int i = 0; i < numCourses; i++)
            graph[i] = new List<int>();

        // [a, b] => b must come before a
        foreach (var p in prerequisites)
        {
            int course = p[0];
            int prereq = p[1];

            graph[prereq].Add(course);
            indegree[course]++;
        }

        var queue = new Queue<int>();

        for (int i = 0; i < numCourses; i++)
        {
            if (indegree[i] == 0)
                queue.Enqueue(i);
        }

        var result = new List<int>();

        while (queue.Count > 0)
        {
            int course = queue.Dequeue();
            result.Add(course);

            foreach (int nextCourse in graph[course])
            {
                indegree[nextCourse]--;

                if (indegree[nextCourse] == 0)
                    queue.Enqueue(nextCourse);
            }
        }

        // If all courses weren't processed, there is a cycle.
        return result.Count == numCourses
            ? result.ToArray()
            : Array.Empty<int>();
    }
}