static SinglyLinkedListNode insertNodeAtPosition(SinglyLinkedListNode llist, int data, int position)
{
    SinglyLinkedListNode newNode = new SinglyLinkedListNode(data);
    
    // If inserting at the head (position 0)
    if (position == 0)
    {
        newNode.next = llist;
        return newNode;
    }

    SinglyLinkedListNode current = llist;
    
    // Traverse to the node just before the target position
    for (int i = 0; i < position - 1 && current != null; i++)
    {
        current = current.next;
    }

    // Insert the new node if the position is valid
    if (current != null)
    {
        newNode.next = current.next;
        current.next = newNode;
    }

    return llist;
}
