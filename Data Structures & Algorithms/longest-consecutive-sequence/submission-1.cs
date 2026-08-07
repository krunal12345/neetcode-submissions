public class Solution
{
    public int LongestConsecutive(int[] nums)
    {
        if (nums.Length == 0)
            return 0;

        var set = new HashSet<int>(nums);
        int longest = 0;

        foreach (int num in set)
        {
            // Only start counting if this is the beginning of a sequence.
            if (!set.Contains(num - 1))
            {
                int current = num;
                int length = 1;

                while (set.Contains(current + 1))
                {
                    current++;
                    length++;
                }

                longest = Math.Max(longest, length);
            }
        }

        return longest;
    }
}