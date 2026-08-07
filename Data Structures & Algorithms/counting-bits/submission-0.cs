public class Solution {
    public int[] CountBits(int n) {
        int[] result = new int[n + 1];
        for(int i = 0; i <= n; i++){
            result[i] = HammingWeight(i);
        }

        return result;
    }

     public int HammingWeight(int n) {
        int res = 0;
        for (int i = 0; i < 32; i++) {
            if ((1 << i & n) != 0) {
                res++;
            }
        }
        return res;
    }
}
