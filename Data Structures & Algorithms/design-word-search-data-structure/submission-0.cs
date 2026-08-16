public class WordDictionary
{
    class TrieNode
    {
        public TrieNode[] children = new TrieNode[26];
        public bool isEndOfWord;
    }

    private TrieNode root;

    public WordDictionary()
    {
        root = new TrieNode();
    }

    public void AddWord(string word)
    {
        TrieNode current = root;

        foreach (char c in word)
        {
            int index = c - 'a';

            if (current.children[index] == null)
            {
                current.children[index] = new TrieNode();
            }

            current = current.children[index];
        }

        current.isEndOfWord = true;
    }

    public bool Search(string word)
    {
        return Search(word, 0, root);
    }

    private bool Search(string word, int index, TrieNode current)
    {
        // Reached the end of the word
        if (index == word.Length)
        {
            return current.isEndOfWord;
        }

        char c = word[index];

        // Normal character
        if (c != '.')
        {
            int childIndex = c - 'a';

            if (current.children[childIndex] == null)
                return false;

            return Search(
                word,
                index + 1,
                current.children[childIndex]
            );
        }

        // '.' → try every possible child
        for (int i = 0; i < 26; i++)
        {
            if (current.children[i] != null)
            {
                if (Search(word, index + 1, current.children[i]))
                    return true;
            }
        }

        return false;
    }
}