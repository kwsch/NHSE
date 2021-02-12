using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace NHSE.Core
{
    /// <summary>
    /// Logic for retrieving resources from the dll
    /// </summary>
    public static class ResourceUtil
    {
        private static readonly Assembly thisAssembly = typeof(ResourceUtil).GetTypeInfo().Assembly;
        private static readonly string[] manifestResourceNames = thisAssembly.GetManifestResourceNames();
        private static readonly Dictionary<string, string> resourceNameMap = new();
        private static readonly Dictionary<string, string[]> stringListCache = new();
        private static readonly object getStringListLoadLock = new();

        public static string[] GetStringList(string fileName)
        {
            if (IsStringListCached(fileName, out var result))
                return result;
            var txt = GetStringResource(fileName); // Fetch File, \n to list.
            return LoadStringList(fileName, txt);
        }

        public static bool IsStringListCached(string fileName, out string[] result)
        {
            lock (getStringListLoadLock) // Make sure only one thread can read the cache
                return stringListCache.TryGetValue(fileName, out result);
        }

        public static string[] LoadStringList(string file, string? txt)
        {
            if (txt == null)
                return Array.Empty<string>();
            string[] rawlist = txt.TrimEnd('\r', '\n').Split('\n');
            for (int i = 0; i < rawlist.Length; i++)
                rawlist[i] = rawlist[i].TrimEnd('\r');

            lock (getStringListLoadLock) // Make sure only one thread can write to the cache
            {
                if (!stringListCache.ContainsKey(file)) // Check cache again in case of race condition
                    stringListCache.Add(file, rawlist);
            }

            return (string[])rawlist.Clone();
        }

        public static string[] GetStringList(string fileName, string lang2char, string type = "text") => GetStringList($"{type}_{fileName}_{lang2char}");

        public static byte[] GetBinaryResource(string name)
        {
            using var resource = thisAssembly.GetManifestResourceStream($"NHSE.Core.Resources.byte.{name}");
            var buffer = new byte[resource.Length];
            resource.Read(buffer, 0, (int)resource.Length);
            return buffer;
        }

        public static ushort[] GetBinaryResourceAsUshort(string name)
        {
            var byteBuffer = GetBinaryResource(name);
            var buffer = new ushort[byteBuffer.Length / 2];
            for (int i = 0; i < byteBuffer.Length / 2; i++)
                buffer[i] = BitConverter.ToUInt16(byteBuffer, i*2);
            return buffer;
        }

        public static string? GetStringResource(string name)
        {
            if (!resourceNameMap.TryGetValue(name, out var resname))
            {
                bool Match(string x) => x.StartsWith("NHSE.Core.Resources.text.") && x.EndsWith($"{name}.txt", StringComparison.OrdinalIgnoreCase);
                resname = Array.Find(manifestResourceNames, Match);
                if (resname == null)
                    return null;
                resourceNameMap.Add(name, resname);
            }

            using var resource = thisAssembly.GetManifestResourceStream(resname);
            if (resource == null)
                return null;
            using var reader = new StreamReader(resource);
            return reader.ReadToEnd();
        }
    }
}