public class Solution {

    public int CountSubstrings(string s) {
        int res = 0;
        for (int i = 0; i < s.Length; i++) {
            res += CountPali(s, i, i);
            res += CountPali(s, i, i + 1);
        }
        return res;
    }

    private int CountPali(string s, int l, int r) {
        int res = 0;
        while (l >= 0 && r < s.Length && s[l] == s[r]) {
            res++;
            l--;
            r++;
        }
        return res;
    }
}