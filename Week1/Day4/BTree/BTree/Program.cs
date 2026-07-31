using System;
using System.Collections.Generic;

public class BTreeNode
{
    public List<int> Keys { get; set; }
    public List<BTreeNode> Children { get; set; }
    public bool IsLeaf { get; set; }

    public BTreeNode(bool isLeaf)
    {
        Keys = new List<int>();
        Children = new List<BTreeNode>();
        IsLeaf = isLeaf;
    }
}

public class BTree
{
    private BTreeNode root;
    private int degree;

    private int maxKeys => 2 * degree - 1;
    private int minKeys => degree - 1;

    public BTree(int degree)
    {
        this.degree = degree;
        root = new BTreeNode(true);
    }

    public void Insert(int key)
    {
        if (root.Keys.Count == maxKeys)
        {
            BTreeNode newRoot = new BTreeNode(false);
            newRoot.Children.Add(root);

            SplitChild(newRoot, 0);

            root = newRoot;
        }

        InsertNonFull(root, key);
    }

    private void InsertNonFull(BTreeNode node, int key)
    {
        int i = node.Keys.Count - 1;

        if (node.IsLeaf)
        {
            node.Keys.Add(0);

            while (i >= 0 && key < node.Keys[i])
            {
                node.Keys[i + 1] = node.Keys[i];
                i--;
            }

            node.Keys[i + 1] = key;
        }
        else
        {
            while (i >= 0 && key < node.Keys[i])
                i--;

            i++;

            if (node.Children[i].Keys.Count == maxKeys)
            {
                SplitChild(node, i);

                if (key > node.Keys[i])
                    i++;
            }

            InsertNonFull(node.Children[i], key);
        }
    }

    private void SplitChild(BTreeNode parent, int index)
    {
        BTreeNode child = parent.Children[index];
        BTreeNode newChild = new BTreeNode(child.IsLeaf);

        // Middle key
        int middleKey = child.Keys[degree - 1];

        // Copy last minKeys keys
        for (int j = degree; j < child.Keys.Count; j++)
        {
            newChild.Keys.Add(child.Keys[j]);
        }

        // Remove copied keys
        child.Keys.RemoveRange(degree, child.Keys.Count - degree);

        // Remove middle key
        child.Keys.RemoveAt(degree - 1);

        // Copy children if not leaf
        if (!child.IsLeaf)
        {
            for (int j = degree; j < child.Children.Count; j++)
            {
                newChild.Children.Add(child.Children[j]);
            }

            child.Children.RemoveRange(degree, child.Children.Count - degree);
        }

        // Insert into parent
        parent.Children.Insert(index + 1, newChild);
        parent.Keys.Insert(index, middleKey);
    }

    // ---------------- DISPLAY ----------------

    public void Display()
    {
        DisplayRecord(root, 0);
    }

    private void DisplayRecord(BTreeNode node, int level)
    {
        Console.Write("Level " + level + " : ");

        foreach (int key in node.Keys)
            Console.Write(key + " ");

        Console.WriteLine();

        if (!node.IsLeaf)
        {
            foreach (BTreeNode child in node.Children)
            {
                DisplayRecord(child, level + 1);
            }
        }
    }

    // ---------------- TRAVERSAL ----------------

    public void Traverse()
    {
        Traverse(root);
        Console.WriteLine();
    }

    private void Traverse(BTreeNode node)
    {
        int i;

        for (i = 0; i < node.Keys.Count; i++)
        {
            if (!node.IsLeaf)
                Traverse(node.Children[i]);

            Console.Write(node.Keys[i] + " ");
        }

        if (!node.IsLeaf)
            Traverse(node.Children[i]);
    }
}

class Program
{
    static void Main()
    {
        BTree tree = new BTree(3);

        tree.Insert(10);
        tree.Insert(20);
        tree.Insert(5);
        tree.Insert(6);
        tree.Insert(12);
        tree.Insert(30);
        tree.Insert(7);
        tree.Insert(17);

        Console.WriteLine("B-Tree Traversal:");
        tree.Traverse();

        Console.WriteLine("\n\nB-Tree Structure:");
        tree.Display();
    }
}