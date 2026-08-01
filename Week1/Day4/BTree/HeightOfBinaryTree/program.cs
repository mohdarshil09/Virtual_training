	static int height(Node root)
{
    if (root == null)
        return -1;

    return Math.Max(height(root.left), height(root.right)) + 1;
}
