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
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        Queue<TreeNode> a = new();
        Queue<TreeNode> b = new();

        Search(root, p.val, a);
        Search(root, q.val, b);
        TreeNode aPrev = null;
        TreeNode bPrev = null;

        while(a.Count > 0 && b.Count > 0){
            var ad = a.Dequeue();
            var bd = b.Dequeue();
            if(ad.val == bd.val){
                aPrev = ad;
                bPrev = bd;
            }else{
                break;
            }
        }

        return aPrev;
    }

    public void Search(TreeNode root, int val, Queue<TreeNode> a){
        a.Enqueue(root);
        if(root.val == val) return;
        if(val < root.val){
            Search(root.left, val, a);
        }else{
            Search(root.right, val, a);
        }
    }
}