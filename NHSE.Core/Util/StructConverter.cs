using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NHSE.Core
{
    /// <summary>
    /// Logic for converting raw data to class/stack struct, and back to data.
    /// </summary>
    public static class StructConverter
    {
        extension(byte[] bytes)
        {
            public T ToStructure<T>() where T : struct
            {
                var handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
                try { return Marshal.PtrToStructure<T>(handle.AddrOfPinnedObject()); }
                finally { handle.Free(); }
            }

            public T ToClass<T>() where T : class
            {
                var handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
                try { return Marshal.PtrToStructure<T>(handle.AddrOfPinnedObject())!; }
                finally { handle.Free(); }
            }

            public T ToStructure<T>(int offset, int length) where T : struct
            {
                var slice = bytes.Slice(offset, length);
                return slice.ToStructure<T>();
            }

            public T ToClass<T>(int offset, int length) where T : class
            {
                var slice = bytes.Slice(offset, length);
                return slice.ToClass<T>();
            }
        }

        public static byte[] ToBytesClass<T>(this T obj) where T : class
        {
            int size = Marshal.SizeOf(obj);
            byte[] arr = new byte[size];

            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(obj, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);
            return arr;
        }

        public static byte[] ToBytes<T>(this T obj) where T : struct
        {
            int size = Marshal.SizeOf(obj);
            byte[] arr = new byte[size];

            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(obj, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);
            return arr;
        }

        public static T[] GetArray<T>(this byte[] data, int size) where T : class
        {
            var result = new T[data.Length / size];
            for (int i = 0; i < result.Length; i++)
                result[i] = data.Slice(i * size, size).ToClass<T>();
            return result;
        }

        public static byte[] SetArray<T>(this IReadOnlyList<T> data, int size) where T : class
        {
            var result = new byte[data.Count * size];
            for (int i = 0; i < data.Count; i++)
                data[i].ToBytesClass().CopyTo(result, i * size);
            return result;
        }

        public static T[] GetArrayStructure<T>(this byte[] data, int size) where T : struct
        {
            var result = new T[data.Length / size];
            for (int i = 0; i < result.Length; i++)
                result[i] = data.Slice(i * size, size).ToStructure<T>();
            return result;
        }

        public static byte[] SetArrayStructure<T>(this IReadOnlyList<T> data, int size) where T : struct
        {
            var result = new byte[data.Count * size];
            for (int i = 0; i < data.Count; i++)
                data[i].ToBytes().CopyTo(result, i * size);
            return result;
        }
    }
}
