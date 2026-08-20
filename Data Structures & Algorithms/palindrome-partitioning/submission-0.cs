public class Solution
{
    public List<List<string>> Partition(string s)
    {
        List<List<string>> result = new();
        List<string> current = new();

        Backtrack(0);

        return result;

        void Backtrack(int start)
        {
            // We have partitioned the entire string
            if (start == s.Length)
            {
                result.Add(new List<string>(current));
                return;
            }

            // Try every possible substring starting at 'start'
            for (int end = start; end < s.Length; end++)
            {
                // Only choose the substring if it is a palindrome
                if (!IsPalindrome(start, end))
                    continue;

                // Choose
                current.Add(s.Substring(start, end - start + 1));

                // Explore
                Backtrack(end + 1);

                // Undo
                current.RemoveAt(current.Count - 1);
            }
        }

        bool IsPalindrome(int left, int right)
        {
            while (left < right)
            {
                if (s[left] != s[right])
                    return false;

                left++;
                right--;
            }

            return true;
        }
    }
}