using System;
using System.Collections.Generic;
using System.Linq;

namespace NHSE.Core
{
    public class MuseumEditor
    {
        public readonly Museum Museum;
        public readonly GSaveDate[] Dates;
        public readonly Item[] Items;
        public readonly byte[] Players;

        public MuseumEditor(Museum museum)
        {
            Museum = museum;
            Dates = museum.GetDates();
            Items = museum.GetItems();
            Players = museum.GetPlayers();
        }

        public void Save()
        {
            var museum = Museum;
            museum.SetDates(Dates);
            museum.SetItems(Items);
            museum.SetPlayers(Players);
        }

        public IEnumerable<string> GetDonationSummary(GameStrings str)
        {
            for (int i = 0; i < Museum.EntryCount; i++)
            {
                var item = Items[i];
                if (item.IsNone)
                    continue;

                yield return GetDonationSummary(str, item, i);
            }
        }

        public string GetDonationSummary(GameStrings str, int index) => GetDonationSummary(str, Items[index], index);

        public string GetDonationText(GameStrings str, int index) => $"{Dates[index]}: {str.GetItemName(Items[index])}";

        private string GetDonationSummary(GameStrings str, Item item, int index)
        {
            var date = Dates[index];
            var player = Players[index];

            var name = str.GetItemName(item);
            var result = $"On {date}, Player {player} donated a(n) {name}.";
            return result;
        }

        public int GiveAll(string[] englishNames, int interval = 20)
        {
            var items = new[]
            {
                GameLists.Art.Where(z => !englishNames[z].Contains('(')), // ignore forgeries
                GameLists.Fish,
                GameLists.Fossils,
                GameLists.Bugs,
            }.SelectMany(z => z).ToArray();

            RandUtil.Shuffle(items);
            return AddItems(items, interval);
        }

        private int AddItems(IEnumerable<ushort> items, int interval = 20)
        {
            var processed = Items.Select(z => z.ItemId).Where(z => z != Item.NONE).Distinct();
            var hashset = new HashSet<ushort>(processed);

            var latestDate = Dates.Max(z => (DateTime)z);
            int added = 0;
            foreach (var id in items)
            {
                if (hashset.Contains(id))
                    continue;

                if (added % interval == 0)
                    latestDate = latestDate.AddDays(1);

                int openIndex = GetFirstOpenIndex();

                Dates[openIndex] = latestDate;
                Items[openIndex] = new Item(id);
                Players[openIndex] = 0; // first player

                added++;
            }

            return added;
        }

        private int GetFirstOpenIndex() => Array.FindIndex(Items, z => z.ItemId == Item.NONE);

        public void SortAll()
        {
            var lump = Enumerable.Range(0, Items.Length)
                .Select(z => new {Index = z, Item = Items[z], Date = Dates[z], Player = Players[z]})
                .OrderBy(z => z.Date.IsEmpty)
                .ThenBy(z => (DateTime)z.Date);

            int ctr = 0;
            foreach (var x in lump)
            {
                Dates[ctr] = x.Date;
                Items[ctr] = x.Item;
                Players[ctr] = x.Player;
                ctr++;
            }
        }
    }
}
