public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        Dictionary<char, int> map = new();

        int left = 0;
        int maxLength = 0;

        for (int right = 0; right < s.Length; right++)
        {
            if (map.TryGetValue(s[right], out int previousIndex))
            {
                left = Math.Max(left, previousIndex + 1);
            }

            map[s[right]] = right;

            maxLength = Math.Max(maxLength, right - left + 1);
        }

        return maxLength;
    }
}