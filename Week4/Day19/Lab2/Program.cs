using System;
using System.Collections.Generic;

class UndoManager
{
    // Stack is appropriate because the most recent action must be undone first.
    private Stack<string> actions = new();

    public void RecordAction(string action)
    {
        actions.Push(action);
    }

    public string? Undo()
    {
        if (actions.Count == 0)
            return null;

        return actions.Pop();
    }
}

class SupportTicketQueue
{
    // Queue is appropriate because tickets are processed in FIFO order.
    private Queue<string> tickets = new();

    public void SubmitTicket(string ticketId)
    {
        tickets.Enqueue(ticketId);
    }

    public string? ProcessNext()
    {
        if (tickets.Count == 0)
            return null;

        return tickets.Dequeue();
    }
}

class ActiveUserTracker
{
    // HashSet is appropriate because it automatically prevents duplicate user IDs.
    private HashSet<int> users = new();

    public void RecordVisit(int userId)
    {
        users.Add(userId);
    }

    public int UniqueVisitorCount()
    {
        return users.Count;
    }
}

class MusicPlaylist
{
    // LinkedList is appropriate for efficient insertion/removal once the node is found.
    private LinkedList<string> songs = new();

    public void Add(string song)
    {
        songs.AddLast(song);
    }

    public void InsertAfter(string afterSong, string newSong)
    {
        LinkedListNode<string>? node = songs.Find(afterSong);

        if (node != null)
            songs.AddAfter(node, newSong);
    }

    public void Remove(string song)
    {
        songs.Remove(song);
    }

    public void Print()
    {
        foreach (string song in songs)
            Console.WriteLine(song);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Lab 2: Collection Choice ===");

        // 1. Undo Stack
        UndoManager undo = new();

        undo.RecordAction("Type Hello");
        undo.RecordAction("Type World");

        Console.WriteLine("Undo: " + undo.Undo());
        Console.WriteLine("Undo: " + undo.Undo());

        // 2. Support Queue
        SupportTicketQueue queue = new();

        queue.SubmitTicket("T001");
        queue.SubmitTicket("T002");

        Console.WriteLine("\nProcess: " + queue.ProcessNext());
        Console.WriteLine("Process: " + queue.ProcessNext());

        // 3. Unique Users
        ActiveUserTracker tracker = new();

        tracker.RecordVisit(101);
        tracker.RecordVisit(102);
        tracker.RecordVisit(101);

        Console.WriteLine("\nUnique visitors: " +
                          tracker.UniqueVisitorCount());

        // 4. Playlist
        MusicPlaylist playlist = new();

        playlist.Add("Song A");
        playlist.Add("Song C");

        playlist.InsertAfter("Song A", "Song B");
        playlist.Remove("Song C");

        Console.WriteLine("\nPlaylist:");
        playlist.Print();
    }
}