public class Solution {  
    List<string> res = new();

    public List<string> GenerateParenthesis(int n) {
        BackTrack(n, new char[n*2], 0, 0);
        return res;
    }

    public void BackTrack(int rp, char[] cur, int i, int op){
        if(rp == 0 && op == 0){
            res.Add(new string(cur));
        }
        if(i == cur.Length) return;

        if(rp == 0 && op > 0){
            cur[i] = ')';
            BackTrack(rp, cur, i + 1, op - 1);
        }else{
            cur[i] = '(';
            BackTrack(rp - 1, cur, i + 1, op + 1);

            if(op > 0){
                cur[i] = ')';
                BackTrack(rp, cur, i + 1, op - 1);
            }
        }
    }
}