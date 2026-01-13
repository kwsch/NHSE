using System;

namespace NHSE.Core;

public static class LevenshteinDistance
{
    /// <summary>
    /// Compute the distance between two strings.
    /// http://www.dotnetperls.com/levenshtein
    /// https://stackoverflow.com/a/13793600
    /// </summary>
    public static int Compute(string s, string t)
    {
        int n = s.Length;
        int m = t.Length;
        int[,] d = new int[n + 1, m + 1];

        // Step 1
        if (n == 0)
            return m;

        if (m == 0)
            return n;

        // Step 2
        for (int i = 0; i <= n; d[i, 0] = i++) { }
        for (int j = 0; j <= m; d[0, j] = j++) { }

        // Step 3
        for (int i = 1; i <= n; i++)
        {
            //Step 4
            for (int j = 1; j <= m; j++)
            {
                // Step 5
                int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                // Step 6
                var x1 = d[i - 1, j] + 1;
                var x2 = d[i, j - 1] + 1;
                var x3 = d[i - 1, j - 1] + cost;
                d[i, j] = Math.Min(Math.Min(x1, x2), x3);
            }
        }

        // Step 7
        return d[n, m];
    }
}