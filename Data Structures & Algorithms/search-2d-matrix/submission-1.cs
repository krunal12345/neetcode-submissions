public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        int n = matrix.Length;
        int m = matrix[0].Length;

        (int row, int col) left = (0, 0);
        (int row, int col) right = (n - 1, m - 1);

        while (left.row * m + left.col <=
               right.row * m + right.col) {

            int midI = (
                left.row * m + left.col +
                right.row * m + right.col
            ) / 2;

            (int row, int col) mid = (midI / m, midI % m);

            if (matrix[mid.row][mid.col] == target)
                return true;

            if (matrix[mid.row][mid.col] > target) {

                if (mid.col == 0) {
                    if (mid.row == 0)
                        return false;

                    right.row = mid.row - 1;
                    right.col = m - 1;
                }
                else {
                    right.col = mid.col - 1;
                    right.row = mid.row;
                }
            }
            else {

                if (mid.col == m - 1) {
                    if (mid.row == n - 1)
                        return false;

                    left.row = mid.row + 1;
                    left.col = 0;
                }
                else {
                    left.col = mid.col + 1;
                    left.row = mid.row;
                }
            }
        }

        return false;
    }
}