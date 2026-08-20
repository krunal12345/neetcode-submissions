public class Solution {
    string[] letters =
    {
        "",     // 0
        "",     // 1
        "abc",  // 2
        "def",  // 3
        "ghi",  // 4
        "jkl",  // 5
        "mno",  // 6
        "pqrs", // 7
        "tuv",  // 8
        "wxyz"  // 9
    };

    List<string> result = new();
    public List<string> LetterCombinations(string digits) {
        
        if(string.IsNullOrEmpty(digits)) return [];
        BackTrack(digits, 0, new char[digits.Length]);
        return result;
    }

    public void BackTrack(string digits, int index, char[] current){
        if (index == digits.Length)
        {
            result.Add(new string(current));
            return;
        }

        var chars = letters[digits[index] - '0'];

        foreach(char c in chars){
            current[index] = c;
            BackTrack(digits, index + 1, current);
        }
    }
}
