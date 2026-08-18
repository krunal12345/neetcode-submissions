public class Solution {
    List<List<int>> res = new();
    public List<List<int>> Permute(int[] nums) {
        BackTrack(nums, new(), new());
        return res;
    }

    public void BackTrack(int[] nums, List<int> current, HashSet<int> used){
        if(current.Count == nums.Length){
            res.Add(current.ToList());
        }

        for(int i = 0; i < nums.Length; i++){
            if(used.Contains(nums[i])) continue;
            current.Add(nums[i]);
            used.Add(nums[i]);
            BackTrack(nums, current, used);
            current.RemoveAt(current.Count - 1);
            used.Remove(nums[i]);
        }
    }
}