public class Solution
{
    public int OrangesRotting(int[][] grid)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;

        Queue<(int r, int c)> queue = new();

        int fresh = 0;

        // Find all rotten fruits and count fresh fruits
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (grid[r][c] == 2)
                {
                    queue.Enqueue((r, c));
                }
                else if (grid[r][c] == 1)
                {
                    fresh++;
                }
            }
        }

        if (fresh == 0)
            return 0;

        int minutes = 0;

        int[][] directions =
        {
            new[] { 1, 0 },
            new[] { -1, 0 },
            new[] { 0, 1 },
            new[] { 0, -1 }
        };

        while (queue.Count > 0 && fresh > 0)
        {
            int levelSize = queue.Count;

            // Process everything that rots during this minute
            for (int i = 0; i < levelSize; i++)
            {
                var (r, c) = queue.Dequeue();

                foreach (var dir in directions)
                {
                    int nr = r + dir[0];
                    int nc = c + dir[1];

                    if (nr < 0 || nr >= rows ||
                        nc < 0 || nc >= cols ||
                        grid[nr][nc] != 1)
                    {
                        continue;
                    }

                    // Fresh -> rotten
                    grid[nr][nc] = 2;
                    fresh--;

                    queue.Enqueue((nr, nc));
                }
            }

            minutes++;
        }

        return fresh == 0 ? minutes : -1;
    }
}