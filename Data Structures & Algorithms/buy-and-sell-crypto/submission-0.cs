public class Solution {

    //[10, 1, 5, 6, 7, 1]
    //[10, 10, 1, 1, 1, 1]
    //[7, 7, 7, 7, 1, 1]
    //[0, -3, 6, 6, 0, 0]

    //[10, 2]
    //[10, 2]
    //[2, 2]

    //[2, 10]
    //[2, 2]
    //[10, 10]

    //[7, 1, 5, 3, 6, 4]
    //[7, 1, 1, 1, 1, 1]
    //[7, 6, 6, 6, 6, 4]

    public int MaxProfit(int[] prices) {
        if(prices.Length < 2) return 0;
        int[] left = new int[prices.Length];
        int[] right = new int[prices.Length];

        int min = prices[0];
        for(int i = 0; i < prices.Length; i++){
            min = Math.Min(min, prices[i]);
            left[i] = min;
        }

        int max = prices[prices.Length - 1];
        for(int i = prices.Length - 1; i >= 0; i--){
            max = Math.Max(prices[i], max);
            right[i] = max;
        }

        int maxProfit = 0;
        for(int i = 0; i < prices.Length; i++){
            maxProfit = Math.Max(maxProfit, right[i] - left[i]);
        }

        return maxProfit;
    }
}