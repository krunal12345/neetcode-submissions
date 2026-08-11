public class Solution
{
    public int CharacterReplacement(string s, int k)
    {
        Dictionary<char, int> frequency = new();

        int left = 0;
        int maxFrequency = 0;
        int maxLength = 0;

        for (int right = 0; right < s.Length; right++)
        {
            frequency[s[right]] = frequency.GetValueOrDefault(s[right]) + 1;

            maxFrequency = Math.Max(maxFrequency, frequency[s[right]]);

            while ((right - left + 1) - maxFrequency > k)
            {
                frequency[s[left]]--;
                left++;
            }

            maxLength = Math.Max(maxLength, right - left + 1);
        }

        return maxLength;
    }
}