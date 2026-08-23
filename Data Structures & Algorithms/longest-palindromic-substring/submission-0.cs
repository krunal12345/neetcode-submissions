public class Solution
{
    public string LongestPalindrome(string s)
    {
        (int left, int right) max = (0, 0);

        for (int i = 0; i < s.Length; i++)
        {
            Validate(i, i, s, ref max);
            Validate(i, i + 1, s, ref max);
        }

        return s.Substring(
            max.left,
            max.right - max.left + 1
        );
    }

    public void Validate(
        int left,
        int right,
        string s,
        ref (int left, int right) max)
    {
        while (left >= 0 &&
               right < s.Length &&
               s[left] == s[right])
        {
            left--;
            right++;
        }

        // We expanded one step too far,
        // so move back inside the palindrome.
        left++;
        right--;

        if (right - left > max.right - max.left)
        {
            max = (left, right);
        }
    }
}