public class Solution
{
    List<List<int>> res = new();
    int[] candidates;

    public List<List<int>> CombinationSum2(int[] candidates, int target)
    {
        this.candidates = candidates;

        Array.Sort(this.candidates);

        Backtrack(0, new List<int>(), target);

        return res;
    }

    void Backtrack(int start, List<int> cur, int remaining)
    {
        if (remaining == 0)
        {
            res.Add(new List<int>(cur));
            return;
        }

        for (int i = start; i < candidates.Length; i++)
        {
            // Duplicate at the same level
            if (i > start && candidates[i] == candidates[i - 1])
                continue;

            // Array is sorted
            if (candidates[i] > remaining)
                break;

            // Take
            cur.Add(candidates[i]);

            Backtrack(
                i + 1,
                cur,
                remaining - candidates[i]
            );

            // Backtrack
            cur.RemoveAt(cur.Count - 1);
        }
    }
}