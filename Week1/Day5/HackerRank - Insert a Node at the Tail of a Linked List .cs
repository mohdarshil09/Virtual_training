  public static SinglyLinkedListNode insertNodeAtTail(SinglyLinkedListNode head, int data)
    {
        // Step 1: Create the new node
        SinglyLinkedListNode newNode = new SinglyLinkedListNode(data);
        
        // Step 2: If the list is empty, the new node becomes the head
        if (head == null)
        {
            return newNode;
        }
        
        // Step 3: Traverse to the last node (tail) of the list
        SinglyLinkedListNode current = head;
        while (current.next != null)
        {
            current = current.next;
        }
        
        // Step 4: Link the new node at the end
        current.next = newNode;
        
        // Step 5: Return the head of the list
        return head;
    }
