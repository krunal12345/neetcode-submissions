public class Solution
{
    public string MinWindow(string s, string t)
    {
        if (s.Length < t.Length)
            return "";

        int[] required = new int[52];
        int[] window = new int[52];

        foreach (char c in t)
        {
            SetFreq(c, GetFreq(c, required) + 1, required);
        }

        int left = 0;

        int formed = 0;
        int requiredTypes = 0;

        for (int i = 0; i < required.Length; i++)
        {
            if (required[i] > 0)
                requiredTypes++;
        }

        int minLength = int.MaxValue;
        int minLeft = 0;

        for (int right = 0; right < s.Length; right++)
        {
            char rightChar = s[right];

            SetFreq(
                rightChar,
                GetFreq(rightChar, window) + 1,
                window
            );

            int index = GetIndex(rightChar);

            if (required[index] > 0 &&
                window[index] == required[index])
            {
                formed++;
            }

            while (formed == requiredTypes)
            {
                int currentLength = right - left + 1;

                if (currentLength < minLength)
                {
                    minLength = currentLength;
                    minLeft = left;
                }

                char leftChar = s[left];
                int leftIndex = GetIndex(leftChar);

                SetFreq(
                    leftChar,
                    GetFreq(leftChar, window) - 1,
                    window
                );

                if (required[leftIndex] > 0 &&
                    window[leftIndex] < required[leftIndex])
                {
                    formed--;
                }

                left++;
            }
        }

        if (minLength == int.MaxValue)
            return "";

        return new string(s.ToCharArray(), minLeft, minLength);
    }

    int GetIndex(char c)
    {
        if (c >= 'a' && c <= 'z')
            return c - 'a';

        return c - 'A' + 26;
    }

    int GetFreq(char c, int[] freq)
    {
        return freq[GetIndex(c)];
    }

    void SetFreq(char c, int value, int[] freq)
    {
        freq[GetIndex(c)] = value;
    }
}