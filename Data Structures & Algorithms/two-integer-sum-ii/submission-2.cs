public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        for(int i = 0, j = numbers.Length - 1; i < j;){
            var sum = numbers[i] + numbers[j];
            if(sum == target){
                return [i + 1 , j + 1];
            }

            if(sum >= target){
                j--;
            }
            else if(sum < target){
                i++;
            }
        }  
        return [0, 0];
    }
}
