public class Solution {
    public bool IsAnagram(string s, string t) {
        if(s.Length != t.Length) {
            return false;
        }
        return sortString(s) == sortString(t);
    }

    public string sortString(string original){
        // 1. Convert to character array
        char[] charArray = original.ToCharArray();

        // 2. Sort the array alphabetically
        Array.Sort(charArray);

        // 3. Convert back to a string
        return new string(charArray);
    }
}
