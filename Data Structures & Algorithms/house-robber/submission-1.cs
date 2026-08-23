public class Solution
{
    public int Rob(int[] nums)
    {
        int prev2 = 0;
        int prev1 = 0;

        foreach (int money in nums)
        {
            int current = Math.Max(
                prev1,              // Skip this house
                prev2 + money      // Rob this house
            );

            prev2 = prev1;
            prev1 = current;
        }

        return prev1;
    }
}