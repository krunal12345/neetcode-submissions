public class Node {
    public int Key { get; set; }
    public int Val { get; set; }
    public Node Prev { get; set; }
    public Node Next { get; set; }

    public Node(int key, int val) {
        Key = key;
        Val = val;
        Prev = null;
        Next = null;
    }
}

public class LRUCache {

    private int cap;
    private Dictionary<int, Node> cache;
    private Node left;
    private Node right;

    public LRUCache(int capacity) {
        cap = capacity;
        cache = new Dictionary<int, Node>();
        left = new Node(0, 0);
        right = new Node(0, 0);
        left.Next = right;
        right.Prev = left;
    }

    private void Remove(Node node) {
        Node prev = node.Prev;
        Node nxt = node.Next;
        prev.Next = nxt;
        nxt.Prev = prev;
    }

    private void Insert(Node node) {
        Node prev = right.Prev;
        prev.Next = node;
        node.Prev = prev;
        node.Next = right;
        right.Prev = node;
    }

    public int Get(int key) {
        if (cache.ContainsKey(key)) {
            Node node = cache[key];
            Remove(node);
            Insert(node);
            return node.Val;
        }
        return -1;
    }

    public void Put(int key, int value) {
        if (cache.ContainsKey(key)) {
            Remove(cache[key]);
        }
        Node newNode = new Node(key, value);
        cache[key] = newNode;
        Insert(newNode);

        if (cache.Count > cap) {
            Node lru = left.Next;
            Remove(lru);
            cache.Remove(lru.Key);
        }
    }
}