/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
 
public class Solution {
    public List<List<int>> LevelOrder(TreeNode root) {
        if(root == null) return [];

        Queue<TreeNode> q = new();
        List<List<int>> res = new();
        q.Enqueue(root);
        ProcessLevel(q, res);
        return res;
    }

    public void ProcessLevel(Queue<TreeNode> q, List<List<int>> res){
        if(q.Count == 0) return;

        List<int> nodes = new();
        List<TreeNode> levelNodes = new();
        while(q.Count > 0){
            var node = q.Dequeue();
            levelNodes.Add(node);
            nodes.Add(node.val);
        }
        res.Add(nodes);

        foreach(TreeNode node in levelNodes){
            if(node.left != null) q.Enqueue(node.left);
            if(node.right != null) q.Enqueue(node.right);
        }

        ProcessLevel(q, res);
    }
}
