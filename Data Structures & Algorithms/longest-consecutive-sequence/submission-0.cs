public class Solution
{
    public int LongestConsecutive(int[] nums)
    {
        var seen = new HashSet<int>();
        var startToEnd = new Dictionary<int, int>();
        var endToStart = new Dictionary<int, int>();

        int maxLength = 0;

        foreach (int num in nums)
        {
            // Ignore duplicates
            if (!seen.Add(num))
                continue;

            bool hasLeft = endToStart.ContainsKey(num - 1);
            bool hasRight = startToEnd.ContainsKey(num + 1);

            if (!hasLeft && !hasRight)
            {
                // Create new interval [num, num]
                startToEnd[num] = num;
                endToStart[num] = num;
                maxLength = Math.Max(maxLength, 1);
            }
            else if (hasLeft && !hasRight)
            {
                // Extend left interval
                int start = endToStart[num - 1];

                startToEnd[start] = num;

                endToStart.Remove(num - 1);
                endToStart[num] = start;

                maxLength = Math.Max(maxLength, num - start + 1);
            }
            else if (!hasLeft && hasRight)
            {
                // Extend right interval
                int end = startToEnd[num + 1];

                startToEnd.Remove(num + 1);
                startToEnd[num] = end;

                endToStart[end] = num;

                maxLength = Math.Max(maxLength, end - num + 1);
            }
            else
            {
                // Merge two intervals
                int leftStart = endToStart[num - 1];
                int rightEnd = startToEnd[num + 1];

                startToEnd.Remove(num + 1);
                endToStart.Remove(num - 1);

                startToEnd[leftStart] = rightEnd;
                endToStart[rightEnd] = leftStart;

                maxLength = Math.Max(maxLength, rightEnd - leftStart + 1);
            }
        }

        return maxLength;
    }
}