public class Solution {
    public int FindMin(int[] nums) {
        //[1,2,3,4,5,6]
        //[2,3,4,5,6,1]
        //[3,4,5,6,1,2]
        //[4,5,6,1,2,3]
        //-->[5,6,1,2,3,4]
        //[6,1,2,3,4,5]
        int left = 0;
        int right = nums.Length - 1;

        int min = nums[0];

        while(left <= right){
            int mid = left + (right - left) / 2;
            if(nums[mid] < min) min = nums[mid];

            if(nums[left] < nums[right]){
                if(nums[left] < nums[mid]){
                    right = mid - 1;
                }else{
                    left = mid + 1;
                }
            }else{
                if(nums[right] > nums[mid]){
                    right = mid - 1;
                }else{
                    left = mid + 1;
                }
            }
        }


        return min;
    }
}
