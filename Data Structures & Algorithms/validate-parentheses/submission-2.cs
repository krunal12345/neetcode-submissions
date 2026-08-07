public class Solution {
    public bool IsValid(string s) {
        Stack<char> st= new Stack<char>();
        Dictionary<char, char> pairs = new Dictionary<char, char>
            {
                { '(', ')' },
                { '[', ']' },
                { '{', '}' }
            };     

        Dictionary<char, char> revPairs = new Dictionary<char, char>
            {
                { ')', '(' },
                { ']', '[' },
                { '}', '{' }
            };          

        char[] arr = s.ToCharArray();
        char[] op = ['(', '{', '['];
        char[] ep = [')', '}', ']'];


        for(int i = 0; i < arr.Length; i++){
            if(ep.Contains(arr[i])){
                if(st.Count == 0) return false;
                char bracket = st.Pop();
                char openingbracket = revPairs.GetValueOrDefault(arr[i]);
                if(bracket != openingbracket) return false;
            }
            if(op.Contains(arr[i])){
                st.Push(arr[i]);
            }
        }

        if(st.Count > 0) return false;

        return true;
    }
}
