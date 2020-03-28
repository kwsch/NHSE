using System.IO;

namespace NHSE.Core
{
    /// <summary>
    /// Stores references for all files in the Villager (<see cref="DirectoryName"/>) folder.
    /// </summary>
    public sealed class Player
    {
        public readonly Personal Personal;
        public readonly PhotoStudioIsland Photo;
        public readonly PostBox PostBox;
        public readonly Profile Profile;

        public readonly string DirectoryName;
        public override string ToString() => Personal.Name;

        public static Player[] ReadMany(string folder)
        {
            var dirs = Directory.GetDirectories(folder, "Villager*", SearchOption.TopDirectoryOnly);
            var result = new Player[dirs.Length];
            for (int i = 0; i <result.Length; i++)
                result[i] = new Player(dirs[i]);
            return result;
        }

        private Player(string folder)
        {
            DirectoryName = new DirectoryInfo(folder).Name;

            Personal = new Personal(folder);
            Photo = new PhotoStudioIsland(folder);
            PostBox = new PostBox(folder);
            Profile = new Profile(folder);
        }

        public void Save(uint seed)
        {
            Personal.Save(seed);
            Photo.Save(seed);
            PostBox.Save(seed);
            Profile.Save(seed);
        }

        public void Hash()
        {
            Personal.Hash();
            Photo.Hash();
            PostBox.Hash();
            Profile.Hash();
        }
    }
}