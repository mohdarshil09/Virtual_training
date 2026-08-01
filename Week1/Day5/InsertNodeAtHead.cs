static SinglyLinkedListNode insertNodeAtHead(SinglyLinkedListNode llist, int data) 
{
    // 1. Create a new node with the given data
    SinglyLinkedListNode newNode = new SinglyLinkedListNode(data);
    
    // 2. Point the new node's next to the current head (handles both null and existing lists)
    newNode.next = llist;
    
    // 3. Return the new node as the new head of the list
    return newNode;
}
