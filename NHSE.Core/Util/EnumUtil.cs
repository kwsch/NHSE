using System;
using System.Collections.Generic;

namespace NHSE.Core
{
    public static class EnumUtil
    {
        public static KeyValuePair<string, string[]> GetEnumList<T>() where T : Enum
        {
            var type = typeof(T);
            var name = type.Name;
            var values = GetTypeValues<T>(type);
            return new KeyValuePair<string, string[]>(name, values);
        }

        private static string[] GetTypeValues<T>(Type type) where T : Enum
        {
            var arr = (T[])Enum.GetValues(type);
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
}
