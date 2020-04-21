using System.IO;

namespace NHSE.WinForms
{
    public static class FileUtil
    {
        public static void CopyFolder(string source, string dest, bool subfolders = true)
        {
            Directory.CreateDirectory(dest);

            var dir = new DirectoryInfo(source);
            foreach (var file in dir.EnumerateFiles())
            {
                var path = Path.Combine(dest, file.Name);
                file.CopyTo(path, false);
            }

            if (!subfolders)
                return;

            foreach (var folder in dir.EnumerateDirectories())
            {
                var path = Path.Combine(dest, folder.Name);
                CopyFolder(folder.FullName, path);
            }
        }
    }
}
