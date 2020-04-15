using System.Collections.Generic;
using System.Linq;

namespace NHSE.Core
{
    /// <summary>
    /// Represents all saved data that is stored on the device for the New Horizon's game.
    /// </summary>
    public class HorizonSave
    {
        public readonly MainSave Main;
        public readonly Player[] Players;
        public override string ToString() => $"{Players[0].Personal.TownName} - {Players[0]}";

        public HorizonSave(string folder)
        {
            Main = new MainSave(folder);
            Players = Player.ReadMany(folder);
        }

        /// <summary>
        /// Saves the data using the provided crypto <see cref="seed"/>.
        /// </summary>
        /// <param name="seed">Seed to initialize the RNG with when encrypting the files.</param>
        public void Save(uint seed)
        {
            Main.Hash();
            Main.Save(seed);
            foreach (var player in Players)
            {
                foreach (var pair in player)
                {
                    pair.Hash();
                    pair.Save(seed);
                }
            }
        }

        /// <summary>
        /// Gets every <see cref="FileHashRegion"/> that is deemed invalid.
        /// </summary>
        /// <remarks>
        /// Doesn't return any metadata about which file the hashes were bad for.
        /// Just check what's returned with what's implemented; the offsets are unique enough.
        /// </remarks>
        public IEnumerable<FileHashRegion> GetInvalidHashes()
        {
            foreach (var hash in Main.InvalidHashes())
                yield return hash;
            foreach (var hash in Players.SelectMany(z => z).SelectMany(z => z.InvalidHashes()))
                yield return hash;
        }

        public void ChangeIdentity(byte[] original, byte[] updated)
        {
            Main.Data.ReplaceOccurrences(original, updated);
            foreach (var pair in Players.SelectMany(z => z))
                pair.Data.ReplaceOccurrences(original, updated);
        }

        public bool ValidateSizes()
        {
            var info = Main.Info.GetKnownRevisionIndex();
            if (info < 0)
                return false;
            var sizes = RevisionChecker.SizeInfo[info];
            if (Main.Data.Length != sizes.Main)
                return false;
            foreach (var p in Players)
            {
                if (p.Personal.Data.Length != sizes.Personal)
                    return false;
                if (p.Photo.Data.Length != sizes.PhotoStudioIsland)
                    return false;
                if (p.PostBox.Data.Length != sizes.PostBox)
                    return false;
                if (p.Profile.Data.Length != sizes.Profile)
                    return false;
            }
            return true;
        }
    }
}
