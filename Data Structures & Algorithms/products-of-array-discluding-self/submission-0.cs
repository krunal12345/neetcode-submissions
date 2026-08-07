public class Solution {
    //[3, 4, 5, 2] input
    //[1, 3, 12, 60]  left side sums
    //[40, 10, 2 , 1]  rightside sums 
    //[40, 30, 24, 60]  result
    public int[] ProductExceptSelf(int[] nums) {
        int[] a = new int[nums.Length];
        a[0] = 1;
        for(int i = 1; i < nums.Length; i++){
            a[i] = a[i - 1] * nums[i - 1];
        }

        //last is now already multiplication of right sides.
        int[] result = new int[nums.Length];
        result[nums.Length -1] = a[nums.Length -1];

        int rightSum = 1;
        for(int j = nums.Length - 2; j >= 0; j--){
            rightSum = rightSum * nums[j + 1];
            result[j] = a[j] * rightSum;
        }

        return result;
    }
}
