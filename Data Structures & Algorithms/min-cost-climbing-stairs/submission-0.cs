public class Solution {
    public int MinCostClimbingStairs(int[] cost) {
        (int totalCost, int floorCost) last = (0, cost[1]);
        (int totalCost, int floorCost) secondLast = (0, cost[0]);

        for(int i = 2; i < cost.Length; i++){
            var a = 
                last.totalCost + last.floorCost 
                    <= secondLast.totalCost + secondLast.floorCost 
                ? last : secondLast;
            var totalCost = (a.totalCost + a.floorCost, cost[i]);
            secondLast = last;
            last = totalCost;
        }

        return Math.Min(last.totalCost + last.floorCost, 
            secondLast.totalCost + secondLast.floorCost);
    }
}
