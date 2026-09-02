public class Solution
{
    public char[][] Solve(char[][] board)
    {
        int rows = board.Length;
        int cols = board[0].Length;

        // Mark all O's connected to the border as safe.
        for (int r = 0; r < rows; r++)
        {
            DFS(board, r, 0, rows, cols);
            DFS(board, r, cols - 1, rows, cols);
        }

        for (int c = 0; c < cols; c++)
        {
            DFS(board, 0, c, rows, cols);
            DFS(board, rows - 1, c, rows, cols);
        }

        // Remaining O's are surrounded.
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (board[r][c] == 'O')
                    board[r][c] = 'X';
                else if (board[r][c] == '#')
                    board[r][c] = 'O';
            }
        }

        return board;
    }

    private void DFS(char[][] board, int r, int c, int rows, int cols)
    {
        if (r < 0 || c < 0 || r >= rows || c >= cols)
            return;

        if (board[r][c] != 'O')
            return;

        // Safe O connected to border
        board[r][c] = '#';

        DFS(board, r + 1, c, rows, cols);
        DFS(board, r - 1, c, rows, cols);
        DFS(board, r, c + 1, rows, cols);
        DFS(board, r, c - 1, rows, cols);
    }
}