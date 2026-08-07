public class Solution
{
    public int Trap(int[] height)
    {
        int n = height.Length;
        if (n < 3)
            return 0;

        int[] leftMax = new int[n];
        int[] rightMax = new int[n];

        // Build leftMax (including current bar)
        leftMax[0] = height[0];
        for (int i = 1; i < n; i++)
        {
            leftMax[i] = Math.Max(leftMax[i - 1], height[i]);
        }

        // Build rightMax (including current bar)
        rightMax[n - 1] = height[n - 1];
        for (int i = n - 2; i >= 0; i--)
        {
            rightMax[i] = Math.Max(rightMax[i + 1], height[i]);
        }

        int water = 0;

        // Calculate trapped water
        for (int i = 0; i < n; i++)
        {
            water += Math.Min(leftMax[i], rightMax[i]) - height[i];
        }

        return water;
    }
}