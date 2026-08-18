public class Solution {
    List<List<int>> res = new List<List<int>>();

    public List<List<int>> SubsetsWithDup(int[] nums) {
        Array.Sort(nums);
        Backtrack(0, new List<int>(), nums);
        return res;
    }

    private void Backtrack(int i, List<int> subset, int[] nums) {
        if (i == nums.Length) {
            res.Add(new List<int>(subset));
            return;
        }

        subset.Add(nums[i]);
        Backtrack(i + 1, subset, nums);
        subset.RemoveAt(subset.Count - 1);

        while (i + 1 < nums.Length && nums[i] == nums[i + 1]) {
            i++;
        }
        Backtrack(i + 1, subset, nums);
    }
}