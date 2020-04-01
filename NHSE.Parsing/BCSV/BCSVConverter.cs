using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NHSE.Parsing
{
    public static class BCSVConverter
    {
        public static IReadOnlyDictionary<uint, BCSVFieldParam> GetFieldDictionary(this BCSV csv)
        {
            return csv.FieldOffsets.ToDictionary(z => z.ColumnKey, z => z);
        }

        public static void DumpAll(string path, string dest, string delim = "\t")
        {
            var files = Directory.EnumerateFiles(path, "*.bcsv");
            Directory.CreateDirectory(dest);
            foreach (var f in files)
            {
                var fn = Path.GetFileNameWithoutExtension(f);
                var df = Path.Combine(dest, $"{fn}.csv");
                Dump(f, df, delim);
            }
        }

        public static void Dump(string path, string dest, string delim = "\t")
        {
            var data = File.ReadAllBytes(path);
            var bcsv = new BCSV(data);
            var result = bcsv.ReadCSV(delim);
            File.WriteAllLines(dest, result);
            Console.WriteLine($"Dumped to CSV: {path}");
        }

        public static BCSV GetBCSV(string pathBCSV, string fn)
        {
            var path = Path.Combine(pathBCSV, fn);
            var data = File.ReadAllBytes(path);
            return new BCSV(data);
        }
    }
}
