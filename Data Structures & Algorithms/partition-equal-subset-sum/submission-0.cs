public class Solution
{
    public bool CanPartition(int[] nums)
    {
        int totalSum = nums.Sum();

        // Odd total cannot be split equally
        if (totalSum % 2 != 0)
            return false;

        int target = totalSum / 2;

        return Backtrack(nums, 0, 0, target);
    }

    private bool Backtrack(int[] nums, int index, int currentSum, int target)
    {
        // Found a subset with target sum
        if (currentSum == target)
            return true;

        // No more elements
        if (index >= nums.Length || currentSum > target)
            return false;

        // Choice 1: Include nums[index]
        if (Backtrack(
            nums,
            index + 1,
            currentSum + nums[index],
            target))
        {
            return true;
        }

        // Choice 2: Don't include nums[index]
        if (Backtrack(
            nums,
            index + 1,
            currentSum,
            target))
        {
            return true;
        }

        return false;
    }
}