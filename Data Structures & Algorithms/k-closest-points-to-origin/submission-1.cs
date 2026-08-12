public class Solution
{
    public int[][] KClosest(int[][] points, int k)
    {
        // Max heap: point with largest distance is at the top
        PriorityQueue<(int x, int y, int distance), int> pq =
            new(Comparer<int>.Create((a, b) => b.CompareTo(a)));

        foreach (int[] point in points)
        {
            int x = point[0];
            int y = point[1];

            // Distance from ORIGIN (0, 0)
            int distance = x * x + y * y;

            if (pq.Count < k)
            {
                pq.Enqueue((x, y, distance), distance);
            }
            else if (distance < pq.Peek().distance)
            {
                pq.Dequeue();
                pq.Enqueue((x, y, distance), distance);
            }
        }

        List<int[]> result = [];

        while (pq.Count > 0)
        {
            var point = pq.Dequeue();
            result.Add([point.x, point.y]);
        }

        return result.ToArray();
    }
}