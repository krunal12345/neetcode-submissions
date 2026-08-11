public class Solution
{
    public bool CheckInclusion(string s1, string s2)
    {
        Dictionary<char, int> fre1 = new Dictionary<char, int>(26);
        Dictionary<char, int> fre2 = new Dictionary<char, int>(26);

        var a1 = s1.ToCharArray();
        var a2 = s2.ToCharArray();

        for (int i = 0; i < a1.Length; i++)
        {
            fre1[a1[i]] = fre1.GetValueOrDefault(a1[i], 0) + 1;
        }

        int left = 0;

        for (int right = 0; right < a2.Length; right++)
        {
            // Character doesn't exist in s1.
            // This window can never be a permutation.
            if (!fre1.ContainsKey(a2[right]))
            {
                fre2.Clear();
                left = right + 1;
                continue;
            }

            fre2[a2[right]] = fre2.GetValueOrDefault(a2[right], 0) + 1;

            // Keep window size equal to s1.Length
            if (right - left + 1 > s1.Length)
            {
                char removed = a2[left];

                fre2[removed]--;

                if (fre2[removed] == 0)
                    fre2.Remove(removed);

                left++;
            }

            // Check only when window has the same length as s1
            if (right - left + 1 == s1.Length)
            {
                if (SameFrequency(fre1, fre2))
                    return true;
            }
        }

        return false;
    }

    bool SameFrequency(
        Dictionary<char, int> a,
        Dictionary<char, int> b)
    {
        if (a.Count != b.Count)
            return false;

        foreach (var pair in a)
        {
            if (!b.TryGetValue(pair.Key, out int frequency) ||
                frequency != pair.Value)
            {
                return false;
            }
        }

        return true;
    }
}