public class Solution
{
    public List<List<int>> Subsets(int[] nums)
    {
        List<List<int>> res = new();
        List<int> subset = new();

        Backtrack(0);

        return res;

        void Backtrack(int index)
        {
            // All numbers have been considered
            if (index == nums.Length)
            {
                res.Add(new List<int>(subset));
                return;
            }

            // Include nums[index]
            subset.Add(nums[index]);
            Backtrack(index + 1);

            // Undo
            subset.RemoveAt(subset.Count - 1);

            // Don't include nums[index]
            Backtrack(index + 1);
        }
    }
}