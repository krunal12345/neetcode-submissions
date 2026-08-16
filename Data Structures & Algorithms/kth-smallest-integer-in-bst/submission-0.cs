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
    public int KthSmallest(TreeNode root, int k) {
        int count = 0;
        return InOrderTraversal(root, ref count, k);
    }

    public int InOrderTraversal(TreeNode node, ref int count, int k){
        if(node == null) return -1;
        var a = InOrderTraversal(node.left, ref count, k);
        count++;
        if(count == k) return node.val;
        var b = InOrderTraversal(node.right, ref count, k);

        return Math.Max(a, b);
    }
}
