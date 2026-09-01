public class Solution
{
    public void islandsAndTreasure(int[][] grid)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;

        Queue<(int r, int c)> queue = new();

        // Add all treasure chests first
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (grid[r][c] == 0)
                {
                    queue.Enqueue((r, c));
                }
            }
        }

        int[][] directions =
        {
            new[] { 1, 0 },
            new[] { -1, 0 },
            new[] { 0, 1 },
            new[] { 0, -1 }
        };

        while (queue.Count > 0)
        {
            var (r, c) = queue.Dequeue();

            foreach (var dir in directions)
            {
                int nr = r + dir[0];
                int nc = c + dir[1];

                if (nr < 0 || nr >= rows ||
                    nc < 0 || nc >= cols)
                {
                    continue;
                }

                // Only process untouched land
                if (grid[nr][nc] != int.MaxValue)
                {
                    continue;
                }

                grid[nr][nc] = grid[r][c] + 1;

                queue.Enqueue((nr, nc));
            }
        }
    }
}