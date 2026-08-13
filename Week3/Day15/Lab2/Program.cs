using System;
using System.Collections.Generic;

namespace Lab2
{
    public class Playlist
    {
        private readonly List<string> _songs = new();

        public void Add(string title) => _songs.Add(title);

        public int Count => _songs.Count;

        // Indexer using integer position
        public string this[int index]
        {
            get => _songs[index];
            set => _songs[index] = value;
        }
    }

    public class TeamRoster
    {
        private readonly Dictionary<string, int> _numbers = new();

        // Indexer using player name
        public int this[string playerName]
        {
            get
            {
                return _numbers.TryGetValue(playerName, out int number)
                    ? number
                    : -1;
            }

            set
            {
                _numbers[playerName] = value;
            }
        }
    }

    public class Matrix
    {
        private readonly int[,] _cells;

        public Matrix(int rows, int cols)
        {
            _cells = new int[rows, cols];
        }

        // Two-parameter indexer
        public int this[int row, int col]
        {
            get => _cells[row, col];
            set => _cells[row, col] = value;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // -------------------------
            // Playlist
            // -------------------------

            Playlist playlist = new Playlist();

            playlist.Add("Song A");
            playlist.Add("Song B");
            playlist.Add("Song C");

            // Replace second song
            playlist[1] = "Song B (Replaced)";

            Console.Write("Playlist: ");

            for (int i = 0; i < playlist.Count; i++)
            {
                Console.Write(playlist[i]);

                if (i < playlist.Count - 1)
                    Console.Write(", ");
            }

            Console.WriteLine();


            // -------------------------
            // TeamRoster
            // -------------------------

            TeamRoster roster = new TeamRoster();

            roster["Alice"] = 7;
            roster["Bob"] = 10;

            Console.WriteLine(
                $"TeamRoster - Alice: {roster["Alice"]}"
            );

            Console.WriteLine(
                $"TeamRoster - Zoe (not on roster): {roster["Zoe"]}"
            );


            // -------------------------
            // Matrix
            // -------------------------

            Matrix matrix = new Matrix(3, 3);

            matrix[0, 0] = 1;
            matrix[0, 2] = 2;
            matrix[1, 1] = 5;
            matrix[2, 0] = 3;

            Console.WriteLine("Matrix:");

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(matrix[row, col]);

                    if (col < 2)
                        Console.Write(" ");
                }

                Console.WriteLine();
            }
        }
    }
}
