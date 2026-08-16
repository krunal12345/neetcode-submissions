public class Solution
{
    int max = int.MinValue;

    public int MaxPathSum(TreeNode root)
    {
        FindMax(root);
        return max;
    }

    int FindMax(TreeNode root)
    {
        if (root == null)
            return 0;

        int left = Math.Max(0, FindMax(root.left));
        int right = Math.Max(0, FindMax(root.right));

        // left + root + right
        int current = left + root.val + right;

        max = Math.Max(max, current);

        // Parent can only continue through ONE side
        return root.val + Math.Max(left, right);
    }
}