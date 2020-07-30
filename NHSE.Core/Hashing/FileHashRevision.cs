namespace NHSE.Core
{
    /// <summary>
    /// Provides information for hashing different revisions of the game's savedata.
    /// </summary>
    public static class FileHashRevision
    {
        #region REVISION 1.0.0

        private const uint REVISION_100_ID = 0;
        private const int MAIN_SAVE_SIZE = 0xAC0938;
        private const int PERSONAL_SAVE_SIZE = 0x6BC50;
        private const int POSTBOX_SAVE_SIZE = 0xB44580;
        private const int PHOTO_STUDIO_ISLAND_SIZE = 0x263B4;
        private const int PROFILE_SIZE = 0x69508;

        public static readonly FileHashInfo REV_100 = new FileHashInfo(REVISION_100_ID, new[]
        {
            new FileHashDetails("main.dat", MAIN_SAVE_SIZE, new[]
            {
                new FileHashRegion(0x000108, 0x1D6D4C),
                new FileHashRegion(0x1D6E58, 0x323384),
                new FileHashRegion(0x4FA2E8, 0x035AC4),
                new FileHashRegion(0x52FDB0, 0x03607C),
                new FileHashRegion(0x565F38, 0x035AC4),
                new FileHashRegion(0x59BA00, 0x03607C),
                new FileHashRegion(0x5D1B88, 0x035AC4),
                new FileHashRegion(0x607650, 0x03607C),
                new FileHashRegion(0x63D7D8, 0x035AC4),
                new FileHashRegion(0x6732A0, 0x03607C),
                new FileHashRegion(0x6A9428, 0x035AC4),
                new FileHashRegion(0x6DEEF0, 0x03607C),
                new FileHashRegion(0x715078, 0x035AC4),
                new FileHashRegion(0x74AB40, 0x03607C),
                new FileHashRegion(0x780CC8, 0x035AC4),
                new FileHashRegion(0x7B6790, 0x03607C),
                new FileHashRegion(0x7EC918, 0x035AC4),
                new FileHashRegion(0x8223E0, 0x03607C),
                new FileHashRegion(0x858460, 0x2684D4)
            }),
            new FileHashDetails("personal.dat", PERSONAL_SAVE_SIZE, new[]
            {
                new FileHashRegion(0x00108, 0x35AC4),
                new FileHashRegion(0x35BD0, 0x3607C)
            }),
            new FileHashDetails("postbox.dat", POSTBOX_SAVE_SIZE, new[]
            {
                new FileHashRegion(0x000100, 0xB4447C)
            }),
            new FileHashDetails("photo_studio_island.dat", PHOTO_STUDIO_ISLAND_SIZE, new[]
            {
                new FileHashRegion(0x000100, 0x262B0)
            }),
            new FileHashDetails("profile.dat", PROFILE_SIZE, new[]
            {
                new FileHashRegion(0x000100, 0x69404)
            }),
        });

        #endregion

        #region REVISION 1.1.0

        private const uint REVISION_110_ID = 1;
        private const int REV_110_MAIN_SAVE_SIZE = 0xAC2AA0;
        private const int REV_110_PERSONAL_SAVE_SIZE = 0x6BED0;
        private const int REV_110_POSTBOX_SAVE_SIZE = 0xB44590;
        private const int REV_110_PHOTO_STUDIO_ISLAND_SIZE = 0x263C0;
        private const int REV_110_PROFILE_SIZE = 0x69560;

        public static readonly FileHashInfo REV_110 = new FileHashInfo(REVISION_110_ID, new[]
        {
            new FileHashDetails("main.dat", REV_110_MAIN_SAVE_SIZE, new[]
            {
                new FileHashRegion(0x000110, 0x1D6D5C),
                new FileHashRegion(0x1D6E70, 0x323C0C),
                new FileHashRegion(0x4FAB90, 0x035AFC),
                new FileHashRegion(0x530690, 0x0362BC),
                new FileHashRegion(0x566A60, 0x035AFC),
                new FileHashRegion(0x59C560, 0x0362BC),
                new FileHashRegion(0x5D2930, 0x035AFC),
                new FileHashRegion(0x608430, 0x0362BC),
                new FileHashRegion(0x63E800, 0x035AFC),
                new FileHashRegion(0x674300, 0x0362BC),
                new FileHashRegion(0x6AA6D0, 0x035AFC),
                new FileHashRegion(0x6E01D0, 0x0362BC),
                new FileHashRegion(0x7165A0, 0x035AFC),
                new FileHashRegion(0x74C0A0, 0x0362BC),
                new FileHashRegion(0x782470, 0x035AFC),
                new FileHashRegion(0x7B7F70, 0x0362BC),
                new FileHashRegion(0x7EE340, 0x035AFC),
                new FileHashRegion(0x823E40, 0x0362BC),
                new FileHashRegion(0x85A100, 0x26899C)
            }),
            new FileHashDetails("personal.dat", REV_110_PERSONAL_SAVE_SIZE, new[]
            {
                new FileHashRegion(0x00110, 0x35AFC),
                new FileHashRegion(0x35C10, 0x362BC)
            }),
            new FileHashDetails("postbox.dat", REV_110_POSTBOX_SAVE_SIZE, new[]
            {
                new FileHashRegion(0x000100, 0xB4448C)
            }),
            new FileHashDetails("photo_studio_island.dat", REV_110_PHOTO_STUDIO_ISLAND_SIZE, new[]
            {
                new FileHashRegion(0x000100, 0x262BC)
            }),
            new FileHashDetails("profile.dat", REV_110_PROFILE_SIZE, new[]
            {
                new FileHashRegion(0x000100, 0x6945C)
            }),
        });

        #endregion

        #region REVISION 1.2.0

        private const uint REVISION_120_ID = 2;
        private const int REV_120_MAIN_SAVE_SIZE = 0xACECD0;
        private const int REV_120_PERSONAL_SAVE_SIZE = 0x6D6C0;
        private const int REV_120_POSTBOX_SAVE_SIZE = REV_110_POSTBOX_SAVE_SIZE;
        private const int REV_120_PHOTO_STUDIO_ISLAND_SIZE = 0x2C9C0;
        private const int REV_120_PROFILE_SIZE = REV_110_PROFILE_SIZE;

        public static readonly FileHashInfo REV_120 = new FileHashInfo(REVISION_120_ID, new[]
        {
            new FileHashDetails("main.dat", REV_120_MAIN_SAVE_SIZE, new[]
            {
                new FileHashRegion(0x000110, 0x1D6D5C),
                new FileHashRegion(0x1D6E70, 0x323EBC),
                new FileHashRegion(0x4FAE40, 0x035D2C),
                new FileHashRegion(0x530B70, 0x03787C),
                new FileHashRegion(0x568500, 0x035D2C),
                new FileHashRegion(0x59E230, 0x03787C),
                new FileHashRegion(0x5D5BC0, 0x035D2C),
                new FileHashRegion(0x60B8F0, 0x03787C),
                new FileHashRegion(0x643280, 0x035D2C),
                new FileHashRegion(0x678FB0, 0x03787C),
                new FileHashRegion(0x6B0940, 0x035D2C),
                new FileHashRegion(0x6E6670, 0x03787C),
                new FileHashRegion(0x71E000, 0x035D2C),
                new FileHashRegion(0x753D30, 0x03787C),
                new FileHashRegion(0x78B6C0, 0x035D2C),
                new FileHashRegion(0x7C13F0, 0x03787C),
                new FileHashRegion(0x7F8D80, 0x035D2C),
                new FileHashRegion(0x82EAB0, 0x03787C),
                new FileHashRegion(0x866330, 0x26899C)
            }),
            new FileHashDetails("personal.dat", REV_120_PERSONAL_SAVE_SIZE, new[]
            {
                new FileHashRegion(0x00110, 0x35D2C),
                new FileHashRegion(0x35E40, 0x3787C)
            }),
            new FileHashDetails("postbox.dat", REV_120_POSTBOX_SAVE_SIZE, new[]
            {
                new FileHashRegion(0x000100, 0xB4448C)
            }),
            new FileHashDetails("photo_studio_island.dat", REV_120_PHOTO_STUDIO_ISLAND_SIZE, new[]
            {
                new FileHashRegion(0x000100, 0x2C8BC)
            }),
            new FileHashDetails("profile.dat", REV_120_PROFILE_SIZE, new[]
            {
                new FileHashRegion(0x000100, 0x6945C)
            }),
        });

        #endregion

        #region REVISION 1.3.0

        private const uint REVISION_130_ID = 3;
        private const int REV_130_MAIN_SAVE_SIZE = 0xACED80;
        private const int REV_130_PERSONAL_SAVE_SIZE = 0x6D6D0;
        private const int REV_130_POSTBOX_SAVE_SIZE = REV_110_POSTBOX_SAVE_SIZE;
        private const int REV_130_PHOTO_STUDIO_ISLAND_SIZE = REV_120_PHOTO_STUDIO_ISLAND_SIZE;
        private const int REV_130_PROFILE_SIZE = REV_110_PROFILE_SIZE;

        public static readonly FileHashInfo REV_130 = new FileHashInfo(REVISION_130_ID, new[]
        {
            new FileHashDetails("main.dat", REV_130_MAIN_SAVE_SIZE, new[]
            {
                new FileHashRegion(0x000110, 0x1D6D5C),
                new FileHashRegion(0x1D6E70, 0x323EEC),
                new FileHashRegion(0x4FAE70, 0x035D2C),
                new FileHashRegion(0x530BA0, 0x03788C),
                new FileHashRegion(0x568540, 0x035D2C),
                new FileHashRegion(0x59E270, 0x03788C),
                new FileHashRegion(0x5D5c10, 0x035D2C),
                new FileHashRegion(0x60B940, 0x03788C),
                new FileHashRegion(0x6432E0, 0x035D2C),
                new FileHashRegion(0x679010, 0x03788C),
                new FileHashRegion(0x6B09B0, 0x035D2C),
                new FileHashRegion(0x6E66E0, 0x03788C),
                new FileHashRegion(0x71E080, 0x035D2C),
                new FileHashRegion(0x753DB0, 0x03788C),
                new FileHashRegion(0x78B750, 0x035D2C),
                new FileHashRegion(0x7C1480, 0x03788C),
                new FileHashRegion(0x7F8E20, 0x035D2C),
                new FileHashRegion(0x82EB50, 0x03788C),
                new FileHashRegion(0x8663E0, 0x26899C)
            }),
            new FileHashDetails("personal.dat", REV_130_PERSONAL_SAVE_SIZE, new[]
            {
                new FileHashRegion(0x00110, 0x35D2C),
                new FileHashRegion(0x35E40, 0x3788C)
            }),
            new FileHashDetails("postbox.dat", REV_130_POSTBOX_SAVE_SIZE, new[]
            {
                new FileHashRegion(0x000100, 0xB4448C)
            }),
            new FileHashDetails("photo_studio_island.dat", REV_130_PHOTO_STUDIO_ISLAND_SIZE, new[]
            {
                new FileHashRegion(0x000100, 0x2C8BC)
            }),
            new FileHashDetails("profile.dat", REV_130_PROFILE_SIZE, new[]
            {
                new FileHashRegion(0x000100, 0x6945C)
            }),
        });

        #endregion

        #region REVISION 1.4.0

        private const uint REVISION_140_ID = 4;
        private const int REV_140_MAIN_SAVE_SIZE = 0xB05790;
        private const int REV_140_PERSONAL_SAVE_SIZE = 0x74420;
        private const int REV_140_POSTBOX_SAVE_SIZE = REV_110_POSTBOX_SAVE_SIZE;
        private const int REV_140_PHOTO_STUDIO_ISLAND_SIZE = REV_120_PHOTO_STUDIO_ISLAND_SIZE;
        private const int REV_140_PROFILE_SIZE = REV_110_PROFILE_SIZE;

        public static readonly FileHashInfo REV_140 = new FileHashInfo(REVISION_140_ID, new[]
        {
            new FileHashDetails("main.dat", REV_140_MAIN_SAVE_SIZE, new[]
            {
                new FileHashRegion(0x000110, 0x1d6d5c),
                new FileHashRegion(0x1d6e70, 0x323f2c),
                new FileHashRegion(0x4faeb0, 0x035d2c),
                new FileHashRegion(0x530be0, 0x03e5dc),
                new FileHashRegion(0x56f2d0, 0x035d2c),
                new FileHashRegion(0x5a5000, 0x03e5dc),
                new FileHashRegion(0x5e36f0, 0x035d2c),
                new FileHashRegion(0x619420, 0x03e5dc),
                new FileHashRegion(0x657b10, 0x035d2c),
                new FileHashRegion(0x68d840, 0x03e5dc),
                new FileHashRegion(0x6cbf30, 0x035d2c),
                new FileHashRegion(0x701c60, 0x03e5dc),
                new FileHashRegion(0x740350, 0x035d2c),
                new FileHashRegion(0x776080, 0x03e5dc),
                new FileHashRegion(0x7b4770, 0x035d2c),
                new FileHashRegion(0x7ea4a0, 0x03e5dc),
                new FileHashRegion(0x828b90, 0x035d2c),
                new FileHashRegion(0x85e8c0, 0x03e5dc),
                new FileHashRegion(0x89cea0, 0x2688ec)
            }),
            new FileHashDetails("personal.dat", REV_140_PERSONAL_SAVE_SIZE, new[]
            {
                new FileHashRegion(0x00110, 0x35D2C),
                new FileHashRegion(0x35E40, 0x3E5DC)
            }),
            new FileHashDetails("postbox.dat", REV_140_POSTBOX_SAVE_SIZE, new[]
            {
                new FileHashRegion(0x000100, 0xB4448C)
            }),
            new FileHashDetails("photo_studio_island.dat", REV_140_PHOTO_STUDIO_ISLAND_SIZE, new[]
            {
                new FileHashRegion(0x000100, 0x2C8BC)
            }),
            new FileHashDetails("profile.dat", REV_140_PROFILE_SIZE, new[]
            {
                new FileHashRegion(0x000100, 0x6945C)
            }),
        });

        #endregion
    }
}
