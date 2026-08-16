public class PrefixTree
{
    LinkedList<TrieNode> roots;

    class TrieNode
    {
        public char data;
        public bool isEndOfString;
        public LinkedList<TrieNode> childs;

        public TrieNode(char a)
        {
            data = a;
            isEndOfString = false;
            childs = new LinkedList<TrieNode>();
        }

        public TrieNode SubNode(char c)
        {
            foreach (TrieNode node in childs)
            {
                if (node.data == c)
                    return node;
            }

            return null;
        }
    }

    public PrefixTree()
    {
        roots = new LinkedList<TrieNode>();
    }

    public void Insert(string word)
    {
        if (string.IsNullOrEmpty(word))
            return;

        LinkedList<TrieNode> nodes = roots;

        for (int i = 0; i < word.Length; i++)
        {
            TrieNode current = nodes.FirstOrDefault(
                node => node.data == word[i]
            );

            if (current == null)
            {
                current = new TrieNode(word[i]);
                nodes.AddLast(current);
            }

            if (i == word.Length - 1)
                current.isEndOfString = true;

            nodes = current.childs;
        }
    }

    public bool Search(string word)
    {
        if (string.IsNullOrEmpty(word))
            return false;

        LinkedList<TrieNode> nodes = roots;

        for (int i = 0; i < word.Length; i++)
        {
            TrieNode current = nodes.FirstOrDefault(
                node => node.data == word[i]
            );

            if (current == null)
                return false;

            if (i == word.Length - 1)
                return current.isEndOfString;

            nodes = current.childs;
        }

        return false;
    }

    public bool StartsWith(string prefix)
    {
        if (string.IsNullOrEmpty(prefix))
            return true;

        LinkedList<TrieNode> nodes = roots;

        for (int i = 0; i < prefix.Length; i++)
        {
            TrieNode current = nodes.FirstOrDefault(
                node => node.data == prefix[i]
            );

            if (current == null)
                return false;

            nodes = current.childs;
        }

        return true;
    }
}