using System;
using System.Collections.Generic;
using System.Linq;
using NHSE.Core;

namespace NHSE.Parsing;

public sealed class BCSVEnumDictionary
{
    private readonly Dictionary<uint, string> _lookup = [];

    public BCSVEnumDictionary(IEnumerable<string> lines)
    {
        foreach (var line in lines)
        {
            var trim = line.Trim();
            if (trim.StartsWith('('))
                AddEnumName(trim);
            if (trim.Contains(" = "))
                AddColumnName(trim);
        }
    }

    private void AddColumnName(string trim)
    {
        if (!trim.EndsWith(')'))
            return;
        if (trim.StartsWith('_'))
            return;

        var text = trim.Split(" = ");

        var name = text[0];
        var value = text[1][(text[1].IndexOf('(') + 1)..];
        var slice = value.AsSpan(2, value.Length - 3);
        var hex = StringUtil.GetHexValue(slice);

        if (_lookup.TryGetValue(hex, out var exist))
        {
            if (exist == name)
                return;
            Console.WriteLine($"Duplicate KVP: {exist} -- old, {name} -- new.");
            return;
        }

        _lookup.Add(hex, name);
    }

    private void AddEnumName(string trim)
    {
        if (!trim.EndsWith("),"))
            return;

        var text = trim.Split('\'')[1];
        if (text.Length == 0)
            return;

        var hash = CRC32.Compute(text);
        if (_lookup.TryGetValue(hash, out var exist))
        {
            if (exist == text)
                return;
            Console.WriteLine($"Duplicate KVP: {exist} -- old, {text} -- new.");
            return;
        }

        _lookup.Add(hash, text);
    }

    public IEnumerable<string> Dump() => _lookup.Select(z => $"{z.Key:X8}\t{z.Value}");

    public string this[uint key] => _lookup.TryGetValue(key, out var val) ? val : $"0x{key:X8}";
}