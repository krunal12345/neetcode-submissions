public class Solution {
    //4 
    //1 1 1 1
    //2 2
    //1 1 2
    //2 1 1
    //1 2 1

    //5
    // 1 1 1 1 1
    // 2 2 1
    // 1 1 2 1
    // 2 1 1 1
    // 1 2 1 1
    // 1 1 1 2
    // 2 1 2
    // 1 2 2

    public int ClimbStairs(int n) {
        if(n == 1) return 1;     
        Dictionary<int, (int totalSteps, int lastOneSteps)> steps = new();
        steps.Add(1, (1, 1));

        for(int i = 2; i <= n; i++){
            (int totalSteps, int lastOneSteps) lastSteps =
                steps.GetValueOrDefault(i - 1, (1 , 1));
            var totalSteps = lastSteps.totalSteps + lastSteps.lastOneSteps;

            steps.Add(i, (totalSteps, lastSteps.totalSteps));
        }

        return steps.GetValueOrDefault(n).totalSteps;
    }
}