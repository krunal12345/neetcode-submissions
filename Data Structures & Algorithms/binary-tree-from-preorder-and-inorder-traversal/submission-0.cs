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
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        return BuildTree(preorder, 0, preorder.Length - 1, inorder, 0, inorder.Length - 1);
    }

    public TreeNode BuildTree(int[] preorder, int preL, int preR, 
     int[] inorder, int inL, int inR) {
        if(preR - preL <= -1) return null;
        if(inR - inL <= -1) return null;

        var root = new TreeNode(preorder[preL]);

        if((preR - preL + 1) == 1){
            return root;            
        }

        var i = inL;
        while(inorder[i] != root.val){
            i++;
        }
        var length = i - inL;

        var left = BuildTree(preorder, preL + 1, preL + 1 + length - 1, inorder, 
            inL, i - 1);
        root.left = left;

        var right = BuildTree(preorder, preL + 1 + length, preR, inorder, i + 1, inR);
        root.right = right;

        return root;
    }
}