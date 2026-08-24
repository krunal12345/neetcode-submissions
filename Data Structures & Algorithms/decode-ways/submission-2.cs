public class Solution {
    //226   2  2  6,  22 6, 2 26
    //1012  10 1  2,  10 12
    //2029  20 2 9,
    //2101  2 10 1,  
    //1123  1 1 2 3, 11 2 3, 1 12 3, 1 1 23,  11 23,
    // 1   1
    // 11  1 + 1, 11  -->  2
    // 112  1 + 1 + 2, 11 2, 1 + 12,  --> 3
    //1123  i + 1 + 2 + 3, 11 2 3, 1 + 12 + 3, 1 + 1 + 23, 11 23, --> 5   

    //10103
    // 1   1   --> 1
    // 10  10  ->  1
    // 1010  10 + 10 --> 1 
    //10103  10 + 10 + 3 --> 1

    //10113
    //1  1  --> 1
    //10   10 --> 1
    //101  10 + 1 --> 1
    //1011  10 + 1 + 1, 10 + 11 --> 2
    //10113  10 + 1 + 1 + 3,  10 + 11 + 3, 10 + 1 + 13 --> 3

    public int NumDecodings(string s)
{
    if (string.IsNullOrEmpty(s) || s[0] == '0')
        return 0;

    int prev2 = 1; // dp[i - 2]
    int prev1 = 1; // dp[i - 1]

    for (int i = 1; i < s.Length; i++)
    {
        int current = 0;

        // Take current digit as a single character
        if (s[i] != '0')
        {
            current += prev1;
        }

        // Take current + previous digit as a two-digit character
        int twoDigit = (s[i - 1] - '0') * 10 + (s[i] - '0');

        if (twoDigit >= 10 && twoDigit <= 26)
        {
            current += prev2;
        }

        prev2 = prev1;
        prev1 = current;
    }

    return prev1;
}
}
