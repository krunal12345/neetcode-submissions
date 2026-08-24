        //[100, 1, 1, 100,  500]
        // 100, 1, 101,101, 501

           //[100, 1,  1,   2,   4,  7,  100, 500] --> 510
//100, 500 //500,501,501,503,505, 510,
public class Solution
{
    public int Rob(int[] nums)
    {
        if (nums.Length == 1)
            return nums[0];

        return Math.Max(
            RobLinear(nums, 0, nums.Length - 2),
            RobLinear(nums, 1, nums.Length - 1)
        );
    }

    private int RobLinear(int[] nums, int start, int end)
    {
        int secondLast = 0;
        int last = 0;

        for (int i = start; i <= end; i++)
        {
            int current = Math.Max(
                last,
                secondLast + nums[i]
            );

            secondLast = last;
            last = current;
        }

        return last;
    }
}
