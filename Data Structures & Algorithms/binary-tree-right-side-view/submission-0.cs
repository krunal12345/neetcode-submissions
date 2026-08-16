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
    public List<int> RightSideView(TreeNode root) {
        if(root == null) return [];
        List<int> result = [];
        Queue<TreeNode> q = new();
        q.Enqueue(root);
        BFS(result, q, 0);
        return result;
    }

    public void BFS(List<int> result, Queue<TreeNode> q, int level){
        if(q.Count == 0) return;
        for(int c = q.Count - 1; c >= 0 ; c--){
            var d = q.Dequeue();
            if(d.right != null) q.Enqueue(d.right);
            if(d.left != null) q.Enqueue(d.left);
            if(result.Count < level + 1){
                result.Add(d.val);
            }
        }

        BFS(result, q, level + 1);
    }
}