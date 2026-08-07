public class Solution {
    public bool IsPalindrome(string s) {
        var s1 = s.ToCharArray().Where(s => char.IsLetterOrDigit(s)).ToArray();
        for(int i = 0, j = s1.Length - 1; i < j; i++, j--){
            if(char.ToLower(s1[i]) != char.ToLower(s1[j])) return false;
        }
        return true;
    }
}
