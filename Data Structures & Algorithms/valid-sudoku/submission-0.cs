public class Solution {
    public bool IsValidSudoku(char[][] board) {
        //dict<row, HashSet<int>>
        //dict<column, HashSet<int>> 
        //this can hel to validate rows and columns
        var rows = new Dictionary<int, HashSet<int>>();
        var cols = new Dictionary<int, HashSet<int>>();
        var grids = new Dictionary<string, HashSet<int>>();

        for(int i = 0; i < 9; i++){
            for(int j = 0; j < 9; j++) {
                if(board[i][j] == '.') continue;
                int ch = board[i][j]  - '0';
                if(ch > 9 || ch < 0) return false;


                int gridRowKey = i / 3;
                int gridColKey = j / 3;

                var rowSet = rows.GetValueOrDefault(i, null);
                var colSet = cols.GetValueOrDefault(j, null);
                string key = gridRowKey.ToString() + gridColKey.ToString();
                var gridSet = grids.GetValueOrDefault(key, null);

                if(rowSet == null){
                    rowSet = new HashSet<int>();
                    rows[i] = rowSet;
                }
                if(colSet == null){
                    colSet = new HashSet<int>();
                    cols[j] = colSet;
                } 
                if(gridSet == null){
                    gridSet = new HashSet<int>();
                    grids[key] = gridSet;
                } 

                if(rowSet.Contains(ch) || colSet.Contains(ch) || gridSet.Contains(ch)){
                    return false;
                }

                colSet.Add(ch);
                rowSet.Add(ch);
                gridSet.Add(ch);
            }
        }

        return true;
    }
}
