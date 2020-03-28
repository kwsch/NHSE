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
                player.Hash();
                player.Save(seed);
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
            return Main.InvalidHashes().Concat(Players.SelectMany(z => z.InvalidHashes()));
        }
    }
}
