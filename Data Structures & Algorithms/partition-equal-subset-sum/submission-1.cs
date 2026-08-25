public class Solution
{
    public bool CanPartition(int[] nums)
    {
        int totalSum = nums.Sum();

        if (totalSum % 2 != 0)
            return false;

        int target = totalSum / 2;

        Dictionary<(int sum, int index), bool> memo = new();

        return Backtrack(nums, 0, 0, target, memo);
    }

    private bool Backtrack(
        int[] nums,
        int index,
        int currentSum,
        int target,
        Dictionary<(int sum, int index), bool> memo)
    {
        if (currentSum == target)
            return true;

        if (index >= nums.Length || currentSum > target)
            return false;

        if (memo.TryGetValue((currentSum, index), out bool result))
            return result;

        bool include = Backtrack(
            nums,
            index + 1,
            currentSum + nums[index],
            target,
            memo);

        bool exclude = Backtrack(
            nums,
            index + 1,
            currentSum,
            target,
            memo);

        memo[(currentSum, index)] = include || exclude;

        return memo[(currentSum, index)];
    }
}