using System.IO;

namespace NHSE.Core
{
    public static class GameFileDumper
    {
        public static void Dump(this HorizonSave sav, string path)
        {
            sav.Main.Dump(path);
            foreach (var p in sav.Players)
            {
                var dir = Path.Combine(path, p.DirectoryName);
                p.Dump(dir);
            }
        }

        public static void Dump(this Player pair, string path)
        {
            pair.Profile.Dump(path);
            pair.Personal.Dump(path);
            pair.Photo.Dump(path);
            pair.PostBox.Dump(path);
        }

        public static void Dump(this EncryptedFilePair pair, string path)
        {
            Dump(path, pair.Data, pair.NameData);
        }

        public static void Dump(string path, byte[] data, string name)
        {
            Directory.CreateDirectory(path);
            var file = Path.Combine(path, name);
            File.WriteAllBytes(file, data);
        }
    }
}
