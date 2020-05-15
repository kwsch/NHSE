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

        public static void Dump(
            string repoPath = @"C:\Users\Kurt\Documents\GitHub",
            string messageStringPath = @"D:\Kurt\Desktop\v12\romSARC\",
            string unpackedMessageFormat = @"Message\String_{0}.sarc.zs\String_{0}.sarc"
            )
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
            DumpRemake(corePath, langID, msbtFolder, langFolderCode);
        }

        private static void DumpVillager(string corePath, string langID, string msbtFolder, string langFolderCode)
        {
            var dest = Path.Combine(corePath, langID, $"text_villager_{langID}.txt");
            var file = string.Format(msbtFolder, langFolderCode);
            var villager = GameMSBTDumper.GetVillagerListResource(file);
            File.WriteAllLines(dest, villager);
        }

        private static void DumpItem(string corePath, string langID, string msbtFolder, string langFolderCode)
        {
            var dest = Path.Combine(corePath, langID, $"text_item_{langID}.txt");
            var file = string.Format(msbtFolder, langFolderCode);
            var items = GameMSBTDumper.GetItemListResource(file);
            File.WriteAllLines(dest, items);
        }

        private static void DumpRemake(string corePath, string langID, string msbtFolder, string langFolderCode)
        {
            Dump("body_color", "STR_Remake_BodyColor.msbt");
            Dump("body_parts", "STR_Remake_BodyParts.msbt");
            Dump("fabric_color", "STR_Remake_FabricColor.msbt");
            Dump("fabric_parts", "STR_Remake_FabricParts.msbt");
            void Dump(string name, string msbt)
            {
                var dest = Path.Combine(corePath, langID, $"text_{name}_{langID}.txt");
                var folder = string.Format(msbtFolder, langFolderCode);
                var file = Path.Combine(folder, "Remake", msbt);

                var lines = GameMSBTDumper.GetLabelList(file);
                var result = lines.Select(z => z.Label.Substring(z.Label.IndexOf('_') + 1) + "\t" + z.Text).OrderBy(z => z);
                File.WriteAllLines(dest, result);
            }
        }
    }
}
