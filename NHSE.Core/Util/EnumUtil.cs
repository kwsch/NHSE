using System;
using System.Collections.Generic;

namespace NHSE.Core;

public static class EnumUtil
{
    public static KeyValuePair<string, string[]> GetEnumList<T>() where T : struct, Enum
    {
        var name = typeof(T).Name;
        var values = GetTypeValues<T>();
        return new KeyValuePair<string, string[]>(name, values);
    }

    private static string[] GetTypeValues<T>() where T : struct, Enum
    {
        var arr = Enum.GetValues<T>();
        var result = new string[arr.Length];
        for (int i = 0; i < arr.Length; i++)
            result[i] = GetSummary(arr[i]);
        return result;
    }

    private static string GetSummary<T>(T z) where T : Enum
    {
        int x = Convert.ToInt32(z);
        return $"{z} = {x}";
    }
}