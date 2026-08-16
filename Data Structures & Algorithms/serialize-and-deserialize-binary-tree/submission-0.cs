public class Codec
{
    public string Serialize(TreeNode root)
    {
        if (root == null)
            return "";

        Queue<TreeNode> q = new();
        List<string> result = new();

        q.Enqueue(root);

        while (q.Count > 0)
        {
            TreeNode node = q.Dequeue();

            if (node == null)
            {
                result.Add("null");
                continue;
            }

            result.Add(node.val.ToString());

            q.Enqueue(node.left);
            q.Enqueue(node.right);
        }

        return string.Join(",", result);
    }

    public TreeNode Deserialize(string data)
    {
        if (string.IsNullOrEmpty(data))
            return null;

        string[] values = data.Split(',');

        TreeNode root = new TreeNode(int.Parse(values[0]));

        Queue<TreeNode> q = new();
        q.Enqueue(root);

        int i = 1;

        while (q.Count > 0)
        {
            TreeNode node = q.Dequeue();

            // Left child
            if (values[i] != "null")
            {
                node.left = new TreeNode(int.Parse(values[i]));
                q.Enqueue(node.left);
            }

            i++;

            // Right child
            if (values[i] != "null")
            {
                node.right = new TreeNode(int.Parse(values[i]));
                q.Enqueue(node.right);
            }

            i++;
        }

        return root;
    }
}