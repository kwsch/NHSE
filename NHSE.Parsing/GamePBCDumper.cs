using System;
using System.IO;
using System.Linq;
using NHSE.Core;

namespace NHSE.Parsing
{
    public static class GamePBCDumper
    {
        public static void DumpOutsideAcrePixels(string modelPath, string path)
        {
            var files = Directory.EnumerateFiles(modelPath, "*.pbc", SearchOption.AllDirectories);

            const int acreSize = 32 * 32 * 4;
            var maxAcre = Enum.GetValues(typeof(OutsideAcre)).Cast<OutsideAcre>().Max();
            var result = new byte[acreSize * ((int)maxAcre + 1)];

            foreach (var f in files)
            {
                var fn = Path.GetFileNameWithoutExtension(f);
                if (fn == null)
                    continue;
                if (!Enum.TryParse<OutsideAcre>(fn, out var acre))
                    continue;

                var data = File.ReadAllBytes(f);
                var pbc = new PBC(data);

                var index = (int)acre;
                var offset = acreSize * index;
                pbc.Tiles.CopyTo(result, offset);
            }
            File.WriteAllBytes(path, result);
		}
    }
}
