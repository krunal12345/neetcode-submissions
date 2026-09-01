/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    Dictionary<Node, Node> mapping;
    HashSet<Node> visited;

    public Node CloneGraph(Node node1) {
        if(node1 == null) return null;
        mapping = new();
        visited = new();

        Queue<Node> nodesToProcess = new();
        nodesToProcess.Enqueue(node1);
        mapping[node1] = new Node(node1.val);

        while(nodesToProcess.Count > 0){
            var node = nodesToProcess.Dequeue();
            var clonedNode = mapping.GetValueOrDefault(node);
            if(clonedNode == null) break;
            visited.Add(node);

            foreach(var child in node.neighbors){
                // Create clone only if it doesn't already exist
                if (!mapping.ContainsKey(child))
                {
                    mapping[child] = new Node(child.val);
                    nodesToProcess.Enqueue(child);
                }

                // ALWAYS connect the cloned nodes
                clonedNode.neighbors.Add(mapping[child]);
            }
        }

        return mapping[node1];
    }
}
