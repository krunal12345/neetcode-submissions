public class Solution {
    public int Search(int[] nums, int target) {
         //[1,2,3,4,5,6]
        //[2,3,4,5,6,1]
        //[3,4,5,6,1,2]
        //[4,5,6,1,2,3]
        //-->[5,6,1,2,3,4]
        //[6,1,2,3,4,5]
        int left = 0;
        int right = nums.Length - 1;

        while(left <= right){
            int mid = left + (right - left) / 2;
            if(nums[mid] == target) return mid;
            if(nums[left] == target) return left;
            if(nums[right] == target) return right;

             if(nums[left] < nums[right]){
                if(nums[mid] > target){
                    right = mid - 1;
                }else{
                    left = mid + 1;
                }
            }else{
                if(nums[right] < nums[mid]){
                    if(target < nums[mid] && target > nums[left]){
                        right = mid - 1;
                    }else{
                        left = mid + 1;
                    }
                }else{
                    if(target > nums[mid] && target < nums[right]){
                        left = mid + 1;
                    }else{
                        right = mid - 1;
                    }
                }
            }


        }
        return -1;
    }
}
