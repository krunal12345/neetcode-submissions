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
    public bool IsValidBST(TreeNode root) {
        List<int> a = new();
        return InOrderTraversal(root, a);
    }

    public bool InOrderTraversal(TreeNode node, List<int> a){
        if(node == null) return true;
        bool left = InOrderTraversal(node.left, a);
        if(left == false) return false;
        if(a.Count == 0 || node.val > a[a.Count - 1]){
            a.Add(node.val);
        }else{
            return false;
        }
        bool right = InOrderTraversal(node.right, a);
        return left && right;
    }
}
