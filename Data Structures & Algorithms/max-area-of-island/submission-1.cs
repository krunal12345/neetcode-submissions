public class Solution
{
    public int MaxAreaOfIsland(int[][] grid)
    {
        int max = 0;

        int rows = grid.Length;
        int cols = grid[0].Length;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (grid[i][j] == 1)
                {
                    int area = DFS(i, j, rows, cols, grid);
                    max = Math.Max(max, area);
                }
            }
        }

        return max;
    }

    public int DFS(int r, int c, int rows, int cols, int[][] grid)
    {
        if (r < 0 || r >= rows ||
            c < 0 || c >= cols ||
            grid[r][c] == 0)
        {
            return 0;
        }

        // Mark visited
        grid[r][c] = 0;

        return 1
            + DFS(r + 1, c, rows, cols, grid)
            + DFS(r - 1, c, rows, cols, grid)
            + DFS(r, c + 1, rows, cols, grid)
            + DFS(r, c - 1, rows, cols, grid);
    }
}