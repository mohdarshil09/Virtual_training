public static long gridlandMetro(int n, int m, int k, List<List<int>> track)
{
    Dictionary<int, List<(long, long)>> rows = new Dictionary<int, List<(long, long)>>();

    foreach (var t in track)
    {
        int r = t[0];

        if (!rows.ContainsKey(r))
            rows[r] = new List<(long, long)>();

        rows[r].Add((t[1], t[2]));
    }

    long occupied = 0;

    foreach (var row in rows.Values)
    {
        row.Sort((a, b) => a.Item1.CompareTo(b.Item1));

        long start = row[0].Item1;
        long end = row[0].Item2;

        for (int i = 1; i < row.Count; i++)
        {
            if (row[i].Item1 <= end + 1)
            {
                end = Math.Max(end, row[i].Item2);
            }
            else
            {
                occupied += end - start + 1;
                start = row[i].Item1;
                end = row[i].Item2;
            }
        }

        occupied += end - start + 1;
    }

    return (long)n * m - occupied;
}
