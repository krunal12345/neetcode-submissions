public class Solution {
    public bool hasDuplicate(int[] nums) {
        var hashSet = new HashSet<int>();
        var hasDuplicates = false;
        foreach(int num in nums){
            if(hashSet.Contains(num)){
                return true;
            }
            hashSet.Add(num);
        }
        return hasDuplicates;
    }
}