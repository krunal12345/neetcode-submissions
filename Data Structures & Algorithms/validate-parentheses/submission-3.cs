public class Solution {
    public bool IsValid(string s) {
        var parens = new Stack<char>();
            foreach (var c in s) {
                if (c == '(') 
                    parens.Push(')');
                else if (c == '{') 
                    parens.Push('}');
                else if (c == '[') 
                    parens.Push(']');
                else if (parens.Count == 0 || parens.Pop() != c) 
                    return false;
            }
            if (parens.Count > 0) return false;
            return true;
    }
}