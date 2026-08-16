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
    public int GoodNodes(TreeNode root) {
        int count = 1;
        AddGoodNodes(root, root, ref count);
        return count;
    }

    public void AddGoodNodes(TreeNode root, TreeNode node, ref int count){
         if(node.left != null){
            if(node.left.val >= root.val){
                count++;
                AddGoodNodes(node.left, node.left, ref count);
            }else{
                AddGoodNodes(root, node.left, ref count);
            }
        }
        if(node.right != null){
            if(node.right.val >= root.val){
                count++;
                AddGoodNodes(node.right, node.right, ref count);
            }else{
                AddGoodNodes(root, node.right, ref count);
            }
        }
    }
}
