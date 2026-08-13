using System;

namespace Lab2
{
    // Base class
    public class LibraryBook
    {
        // Private: accessible only inside LibraryBook
        private string _isbn;

        // Public: accessible from anywhere
        public string Title;

        // Protected: accessible inside LibraryBook and derived classes
        protected string ShelfLocation = "Unassigned";

        // Internal: accessible anywhere within the same project/assembly
        internal int CopiesAvailable;

        // Static: one shared variable for all LibraryBook objects
        public static int TotalBooksCreated;


        // Constructor
        public LibraryBook(string title, string isbn)
        {
            Title = title;
            _isbn = isbn;

            // Every new book starts with 1 copy
            CopiesAvailable = 1;

            // Increase shared counter
            TotalBooksCreated++;
        }


        // Protected internal:
        // Accessible inside this class, derived classes,
        // and other code in the same assembly.
        protected internal void Relocate(string newLocation)
        {
            ShelfLocation = newLocation;
        }


        // Private protected:
        // Accessible only inside LibraryBook and derived classes
        // within the same assembly.
        private protected void AdjustCopies(int delta)
        {
            CopiesAvailable += delta;
        }
    }


    // Derived class
    public class ReferenceBook : LibraryBook
    {
        public ReferenceBook(string title, string isbn)
            : base(title, isbn)
        {
        }


        public void PrintLocation()
        {
            // Access protected field
            Console.WriteLine(
                $"ReferenceBook shelf location before Relocate: \"{ShelfLocation}\""
            );

            // Access protected internal method
            Relocate("Reference Section");

            Console.WriteLine(
                $"ReferenceBook shelf location after Relocate: \"{ShelfLocation}\""
            );

            // Access private protected method
            AdjustCopies(2);

            Console.WriteLine(
                $"Copies available after AdjustCopies(+2): {CopiesAvailable}"
            );
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            // Create first book
            LibraryBook book1 =
                new LibraryBook("C# Basics", "ISBN001");

            Console.WriteLine(
                $"Book 1 created. Total books so far: {LibraryBook.TotalBooksCreated}"
            );


            // Create second book
            LibraryBook book2 =
                new LibraryBook("OOP in C#", "ISBN002");

            Console.WriteLine(
                $"Book 2 created. Total books so far: {LibraryBook.TotalBooksCreated}"
            );


            // Create third book
            LibraryBook book3 =
                new LibraryBook("Data Structures", "ISBN003");

            Console.WriteLine(
                $"Book 3 created. Total books so far: {LibraryBook.TotalBooksCreated}"
            );


            // Create ReferenceBook
            ReferenceBook referenceBook =
                new ReferenceBook("C# Reference", "ISBN004");

            // Demonstrate protected/protected internal/private protected
            referenceBook.PrintLocation();
        }
    }
}