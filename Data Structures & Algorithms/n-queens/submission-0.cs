public class Solution {
    List<List<string>> result = new();

    public List<List<string>> SolveNQueens(int n) {

        List<string> board = new();
        for(int i = 0; i < n; i++){
            char[] row = new char[n];
            for(int j = 0; j < n; j++){
                row[j] = '.';
            }
            board.Add(new string(row));
        }

        BackTrack(board, n, 0, 0, new());

        return result;
    }

    void BackTrack(List<string> board, int total, int row, int col, 
        List<(int r, int c)> pos)
    {
        if(pos.Count == total){
            result.Add(new List<string>(board));
            return;
        }

        if(row == total || col == total) return;

        if(validatePosition(row, col, pos)){
            board[row] = board[row].Remove(col, 1).Insert(col, "Q");

            pos.Add((row, col));

            BackTrack(board, total, row + 1, 0, pos);

            pos.Remove((row, col));

            board[row] = board[row].Remove(col, 1).Insert(col, ".");

            BackTrack(board, total, row, col + 1, pos);
        }
        else{
            BackTrack(board, total, row, col + 1, pos);
        }
    }

    bool validatePosition(int row, int col, List<(int r, int c)> pos){
        if(pos.Count == 0) return true;

        return !pos.Any(pos => 
            pos.r == row || 
            pos.c == col || 
            pos.r - pos.c == row - col || 
            pos.r + pos.c == row + col);
    }
}