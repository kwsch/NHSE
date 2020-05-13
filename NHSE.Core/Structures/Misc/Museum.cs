using System;
using System.Collections.Generic;

namespace NHSE.Core
{
    public class Museum
    {
        public const int SIZE = 0x3404;
        public const int EntryCount = 1024;

        public readonly byte[] Data;

        public Museum(byte[] data) => Data = data;

        public int MuseumLevel
        {
            get => BitConverter.ToInt32(Data, 0x00);
            set => BitConverter.GetBytes(value).CopyTo(Data, 0x00);
        }

        public GSaveDate[] GetDates() => Data.Slice(0x0004, 0x1000).GetArrayStructure<GSaveDate>(GSaveDate.SIZE);
        public void SetDates(IReadOnlyList<GSaveDate> value) => value.SetArrayStructure(GSaveDate.SIZE).CopyTo(Data, 4);

        public Item[] GetItems() => Data.Slice(0x1004, 0x2000).GetArray<Item>(Item.SIZE);
        public void SetItems(IReadOnlyList<Item> value) => value.SetArray(Item.SIZE).CopyTo(Data, 0x1004);

        public byte[] GetPlayers() => Data.Slice(0x3004, 0x400);
        public void SetPlayers(byte[] value) => value.CopyTo(Data, 0x3004);
    }
}
