public class Solution {
    private Dictionary<int, int> memo = new Dictionary<int, int>();

    private int Dfs(int amount, int[] coins) {
        if (amount == 0) return 0;
        if (memo.ContainsKey(amount))
            return memo[amount];

        int res = int.MaxValue;
        foreach (int coin in coins) {
            if (amount - coin >= 0) {
                int result = Dfs(amount - coin, coins);
                if (result != int.MaxValue) {
                    res = Math.Min(res, 1 + result);
                }
            }
        }

        memo[amount] = res;
        return res;
    }

    public int CoinChange(int[] coins, int amount) {
        int minCoins = Dfs(amount, coins);
        return minCoins == int.MaxValue ? -1 : minCoins;
    }
}