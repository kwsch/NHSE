using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NHSE.Core
{
    /// <summary>
    /// Stores references for all files in the Villager (<see cref="DirectoryName"/>) folder.
    /// </summary>
    public sealed class Player : IEnumerable<EncryptedFilePair>
    {
        public readonly Personal Personal;
        public readonly PhotoStudioIsland Photo;
        public readonly PostBox PostBox;
        public readonly Profile Profile;

        /// <summary>
        /// Directory Name where the player data was loaded from. Not the full path.
        /// </summary>
        public readonly string DirectoryName;

        #region Override Implementations
        public IEnumerator<EncryptedFilePair> GetEnumerator() => new EncryptedFilePair[] {Personal, Photo, PostBox, Profile}.AsEnumerable().GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public override string ToString() => Personal.PlayerName;
        #endregion

        /// <summary>
        /// Imports Player data from the requested <see cref="folder"/>.
        /// </summary>
        /// <param name="folder">Folder that contains the Player Villager sub-folders.</param>
        /// <returns>Player object array loaded from the <see cref="folder"/>.</returns>
        public static Player[] ReadMany(string folder)
        {
            var dirs = Directory.GetDirectories(folder, "Villager*", SearchOption.TopDirectoryOnly);
            var result = new Player[dirs.Length];
            for (int i = 0; i < result.Length; i++)
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
    }
}
