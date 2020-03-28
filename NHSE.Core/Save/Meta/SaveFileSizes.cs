namespace NHSE.Core
{
    /// <summary>
    /// Stores file sizes for various savedata files at different patch revisions.
    /// </summary>
    public class SaveFileSizes
    {
        public readonly uint Main;
        public readonly uint Personal;
        public readonly uint PhotoStudioIsland;
        public readonly uint PostBox;
        public readonly uint Profile;

        public SaveFileSizes(uint main, uint personal, uint photo, uint postbox, uint profile)
        {
            Main = main;
            Personal = personal;
            PhotoStudioIsland = photo;
            PostBox = postbox;
            Profile = profile;
        }
    }
}