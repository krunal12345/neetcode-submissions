public class Solution {
    public List<List<int>> PacificAtlantic(int[][] heights) {
        var rows = heights.Length;
        var cols = heights[0].Length;

        bool[,] pacific = new bool[rows,cols];
        bool[,] atlantic = new bool[rows,cols];

        for(int i = 0; i < cols; i++){
            DFS(heights, 0, i, rows, cols, pacific);
            DFS(heights, rows - 1, i, rows, cols, atlantic);
        }

        for(int i = 0; i < rows; i++){
            DFS(heights, i, 0, rows, cols, pacific);
            DFS(heights, i, cols - 1, rows, cols, atlantic);
        }

        var result = new List<List<int>>();
        for(int i = 0; i < rows; i++){
            for(int j = 0; j < cols; j++){
                if(pacific[i,j] && atlantic[i,j]){
                    result.Add([i, j]);
                }
            }
        }

        return result;
    }

    public void DFS(int[][] heights, int r, int c, int rows, int cols, bool[,] ocean
    ){
        if(r < 0 || r == rows || c < 0 || c == cols || ocean[r, c] ) return;

        ocean[r, c] = true;

        if(r + 1 < rows && heights[r + 1][c] >= heights[r][c]){
            DFS(heights, r + 1, c, rows, cols, ocean);
        }
        if(r - 1 >= 0 && heights[r - 1][c] >= heights[r][c]){
            DFS(heights, r - 1, c, rows, cols, ocean);
        }
        if(c + 1 < cols && heights[r][c + 1] >= heights[r][c]){
            DFS(heights, r, c + 1, rows, cols, ocean);
        }
        if(c - 1 >= 0 && heights[r][c - 1] >= heights[r][c]){
            DFS(heights, r, c - 1, rows, cols, ocean);
        }
    }
}
