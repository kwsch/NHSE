using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NHSE.Parsing
{
    /// <summary>
    /// Logic for dumping intermediary assets used by NHSE
    /// </summary>
    public static class GameMSBTDumperNHSE
    {
        /// <summary>
        /// NHSE language code -> Game Language identifier
        /// </summary>
        private static readonly IReadOnlyDictionary<string, string> Languages = new Dictionary<string, string>
        {
            {"en", "USen"},
            {"jp", "JPja"},
            {"zhs", "CNzh"},
            {"zht", "TWzh"},
            {"de", "EUde"},
            {"fr", "EUfr"},
            {"it", "EUit"},
            {"es", "EUes"},
            {"ko", "KRko"},
        };

        public static void Dump(string repoPath, string messageStringPath, string unpackedMessageFormat)
        {
            string corePath = Path.Combine(repoPath, @"NHSE\NHSE.Core\Resources\text\");
            string folder = Path.Combine(messageStringPath, unpackedMessageFormat);

            foreach (var entry in Languages)
                DumpLanguageResources(entry, corePath, folder);
        }

        private static void DumpLanguageResources(KeyValuePair<string, string> entry, string corePath, string msbtFolder)
        {
            var langID = entry.Key;
            var langFolderCode = entry.Value;
            DumpItem(corePath, langID, msbtFolder, langFolderCode);
            DumpVillager(corePath, langID, msbtFolder, langFolderCode);
            DumpVillagerPhrase(corePath, langID, msbtFolder, langFolderCode);
            DumpRemake(corePath, langID, msbtFolder, langFolderCode);
        }

        private static void DumpVillager(string corePath, string langID, string msbtFolder, string langFolderCode)
        {
            var dest = Path.Combine(corePath, langID, $"text_villager_{langID}.txt");
            var file = string.Format(msbtFolder, langFolderCode);
            var villager = GameMSBTDumper.GetVillagerListResource(file);
            File.WriteAllLines(dest, villager);
        }

        private static void DumpVillagerPhrase(string corePath, string langID, string msbtFolder, string langFolderCode)
        {
            var dest = Path.Combine(corePath, langID, $"text_phrase_{langID}.txt");
            var file = string.Format(msbtFolder, langFolderCode);
            var villager = GameMSBTDumper.GetVillagerPhraseResource(file);
            File.WriteAllLines(dest, villager);
        }

        private static void DumpItem(string corePath, string langID, string msbtFolder, string langFolderCode)
        {
            var dest = Path.Combine(corePath, langID, $"text_item_{langID}.txt");
            var file = string.Format(msbtFolder, langFolderCode);
            var items = GameMSBTDumper.GetItemListResource(file, langID);
            File.WriteAllLines(dest, items);
        }

        private static void DumpRemake(string corePath, string langID, string msbtFolder, string langFolderCode)
        {
            DumpMSBT("body_color", "STR_Remake_BodyColor.msbt");
            DumpMSBT("body_parts", "STR_Remake_BodyParts.msbt");
            DumpMSBT("fabric_color", "STR_Remake_FabricColor.msbt");
            DumpMSBT("fabric_parts", "STR_Remake_FabricParts.msbt");
            void DumpMSBT(string name, string msbt)
            {
                var dest = Path.Combine(corePath, langID, $"text_{name}_{langID}.txt");
                var folder = string.Format(msbtFolder, langFolderCode);
                var file = Path.Combine(folder, "Remake", msbt);

                var lines = GameMSBTDumper.GetLabelList(file);
                var result = lines.Select(z => z.Label[(z.Label.IndexOf('_') + 1)..] + "\t" + z.Text).Order();
                File.WriteAllLines(dest, result);
            }
        }
    }
}
