public class Solution {
    public int MaxProduct(int[] nums) {
        int res = nums[0];
        int curMin = 1, curMax = 1;

        foreach (int num in nums) {
            int tmp = curMax * num;
            curMax = Math.Max(Math.Max(num * curMax, num * curMin), num);
            curMin = Math.Min(Math.Min(tmp, num * curMin), num);
            res = Math.Max(res, curMax);
        }
        return res;
    }
}