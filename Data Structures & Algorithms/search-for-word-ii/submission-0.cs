public class TrieNode {
    public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
    public bool IsWord = false;

    public void AddWord(string word) {
        TrieNode cur = this;
        foreach (char c in word) {
            if (!cur.Children.ContainsKey(c)) {
                cur.Children[c] = new TrieNode();
            }
            cur = cur.Children[c];
        }
        cur.IsWord = true;
    }
}

public class Solution {
    private HashSet<string> res = new HashSet<string>();
    private bool[,] visit;
    public List<string> FindWords(char[][] board, string[] words) {
        TrieNode root = new TrieNode();
        foreach (string word in words) {
            root.AddWord(word);
        }

        int ROWS = board.Length, COLS = board[0].Length;
        visit = new bool[ROWS, COLS];

        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                Dfs(board, r, c, root, "");
            }
        }
        return new List<string>(res);
    }

    private void Dfs(char[][] board, int r, int c, TrieNode node, string word) {
        int ROWS = board.Length, COLS = board[0].Length;
        if (r < 0 || c < 0 || r >= ROWS ||
            c >= COLS || visit[r, c] ||
            !node.Children.ContainsKey(board[r][c])) {
            return;
        }

        visit[r, c] = true;
        node = node.Children[board[r][c]];
        word += board[r][c];
        if (node.IsWord) {
            res.Add(word);
        }

        Dfs(board, r + 1, c, node, word);
        Dfs(board, r - 1, c, node, word);
        Dfs(board, r, c + 1, node, word);
        Dfs(board, r, c - 1, node, word);

        visit[r, c] = false;
    }
}