public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        //dict of  value of  index of value, (target - index value);
        var hashSet = new Dictionary<int, int>();
        for(int i = 0; i < nums.Length; i++){
            var index = hashSet.GetValueOrDefault(nums[i], -1);
            if(index != -1){
                return [index, i];
            }
            hashSet.Add(target - nums[i], i); 
        }

        return [-1, -1];
    }
}
