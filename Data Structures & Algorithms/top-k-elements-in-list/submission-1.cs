public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        var dict = new Dictionary<int, int>();
        for(int i = 0; i < nums.Length; i++){
            var fre = dict.GetValueOrDefault(nums[i], 0);
            dict[nums[i]] = ++fre;
        }

        return dict.OrderByDescending(kvp => kvp.Value)
            .Take(k).Select(v => v.Key).ToArray(); 
    }
}
