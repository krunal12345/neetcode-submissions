public class Solution {
    public int MinEatingSpeed(int[] piles, int h) {
        int right = piles.Max();
        int left = 1;

        int minSpeed = 0;

        while(left <= right){
            int mid = left + (right - left) / 2;
            bool can = canEatBananasInSpeed(mid, piles, h);
            if(can){
                minSpeed = mid;
                right = mid - 1;
            }else if(!can){
                left = mid + 1;
            }
        }

        return minSpeed;
    }

    public bool canEatBananasInSpeed(int speed, int[] piles, int h){
        int takenHours = 0;
        for(int i = 0; i < piles.Length; i++){
            takenHours += (int)Math.Ceiling((double)piles[i] / speed);
        }
        return takenHours <= h;
    }
}
