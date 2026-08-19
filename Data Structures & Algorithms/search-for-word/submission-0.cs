public class Solution {
    public bool Exist(char[][] board, string word) {
        var rows =  board.Length;
        var cols = board[0].Length;
        var visited = new bool[rows, cols];

        for(int i = 0; i < rows; i++){
            for(int j = 0; j < cols; j++)
            {
                if (DFS(0, i, j, board, rows, cols, word, visited))
                    return true;
            }
        }
        return false;
    }

    public bool DFS(int i, int row, int col, char[][] board, 
        int rows, int cols, string word, bool[,] visited){

        if(i == word.Length) return true;
        if(
            row < 0 || col < 0 || row == rows || col == cols 
            || visited[row,col] || board[row][col] != word[i]
        ){
            return false;
        }

        visited[row, col] = true;
        var a = DFS(i + 1, row + 1, col, board, rows, cols, word, visited);
        var b = DFS(i + 1, row - 1, col, board, rows, cols, word, visited);
        var c = DFS(i + 1, row, col + 1, board, rows, cols, word, visited);
        var d = DFS(i + 1, row, col - 1, board, rows, cols, word, visited);
        visited[row, col] = false;

        return a || b || c || d;
    }
}
