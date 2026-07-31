using System;

public class BSTNode
{
    public int Value { get; set; }
    public BSTNode Left { get; set; }
    public BSTNode Right { get; set; }

    public BSTNode(int value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}

public class BST
{
    public BSTNode Root { get; set; }

    public BST()
    {
        Root = null;
    }

    // Insert
    public void Insert(int value)
    {
        Root = InsertRec(Root, value);
    }

    private BSTNode InsertRec(BSTNode node, int value)
    {
        if (node == null)
            return new BSTNode(value);

        if (value < node.Value)
            node.Left = InsertRec(node.Left, value);
        else if (value > node.Value)
            node.Right = InsertRec(node.Right, value);

        return node;
    }

    // Search
    public BSTNode Search(int value)
    {
        return SearchRec(Root, value);
    }

    private BSTNode SearchRec(BSTNode node, int value)
    {
        if (node == null || node.Value == value)
            return node;

        if (value < node.Value)
            return SearchRec(node.Left, value);

        return SearchRec(node.Right, value);
    }

    // Delete
    public void Delete(int value)
    {
        Root = DeleteRec(Root, value);
    }

    private BSTNode DeleteRec(BSTNode node, int value)
    {
        if (node == null)
            return null;

        if (value < node.Value)
            node.Left = DeleteRec(node.Left, value);
        else if (value > node.Value)
            node.Right = DeleteRec(node.Right, value);
        else
        {
            // Case 1: No child
            if (node.Left == null && node.Right == null)
                return null;

            // Case 2: One child
            if (node.Left == null)
                return node.Right;

            if (node.Right == null)
                return node.Left;

            // Case 3: Two children
            BSTNode successor = MinValueNode(node.Right);
            node.Value = successor.Value;
            node.Right = DeleteRec(node.Right, successor.Value);
        }

        return node;
    }

    private BSTNode MinValueNode(BSTNode node)
    {
        BSTNode current = node;

        while (current.Left != null)
            current = current.Left;

        return current;
    }

    // Inorder Traversal
    public void Inorder()
    {
        InorderRec(Root);
        Console.WriteLine();
    }

    private void InorderRec(BSTNode node)
    {
        if (node != null)
        {
            InorderRec(node.Left);
            Console.Write(node.Value + " ");
            InorderRec(node.Right);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        BST tree = new BST();

        // Insert nodes
        tree.Insert(50);
        tree.Insert(30);
        tree.Insert(70);
        tree.Insert(20);
        tree.Insert(40);
        tree.Insert(60);
        tree.Insert(80);

        Console.WriteLine("Inorder Traversal:");
        tree.Inorder();

        // Search
        int searchValue = 40;
        BSTNode result = tree.Search(searchValue);

        if (result != null)
            Console.WriteLine(searchValue + " found in the tree.");
        else
            Console.WriteLine(searchValue + " not found.");

        // Delete
        Console.WriteLine("\nDeleting 30...");
        tree.Delete(30);

        Console.WriteLine("Inorder Traversal after deletion:");
        tree.Inorder();

        Console.ReadKey();
    }
}