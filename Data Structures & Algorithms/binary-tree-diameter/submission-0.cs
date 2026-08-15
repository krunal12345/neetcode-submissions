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
    public int DiameterOfBinaryTree(TreeNode root) {
        if(root == null) return 0;
        int max = 0;

        Height(root, ref max);

        return max;
    }

    public int Height(TreeNode node, ref int max){
        if(node == null) return 0;
        var leftHeight = Height(node.left, ref max);
        var rightHeight = Height(node.right, ref max);
        if(max < (leftHeight) + (rightHeight)){
            max = (leftHeight) + (rightHeight);
        }

        return Math.Max(leftHeight, rightHeight) + 1;
    }
}
