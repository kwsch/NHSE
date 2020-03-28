namespace NHSE.Core
{
    /// <summary>
    /// photo_studio_island.dat
    /// </summary>
    public sealed class PhotoStudioIsland : EncryptedFilePair
    {
        public PhotoStudioIsland(string folder) : base(folder, "photo_studio_island") { }
    }
}