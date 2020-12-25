namespace NHSE.Core
{
    /// <summary>
    /// Provides information for hashing different revisions of the game's savedata.
    /// </summary>
    public static class FileHashRevision
    {
        #region REVISION 1.0.0

        private const int MAIN_SAVE_SIZE = 0xAC0938;
        private const int PERSONAL_SAVE_SIZE = 0x6BC50;
        private const int POSTBOX_SAVE_SIZE = 0xB44580;
        private const int PHOTO_STUDIO_ISLAND_SIZE = 0x263B4;
        private const int PROFILE_SIZE = 0x69508;

        public static readonly FileHashInfo REV_100 = new(new FileHashDetails[]
        {
            new("main.dat", MAIN_SAVE_SIZE, new FileHashRegion[]
            {
                new(0x000108, 0x1D6D4C),
                new(0x1D6E58, 0x323384),
                new(0x4FA2E8, 0x035AC4),
                new(0x52FDB0, 0x03607C),
                new(0x565F38, 0x035AC4),
                new(0x59BA00, 0x03607C),
                new(0x5D1B88, 0x035AC4),
                new(0x607650, 0x03607C),
                new(0x63D7D8, 0x035AC4),
                new(0x6732A0, 0x03607C),
                new(0x6A9428, 0x035AC4),
                new(0x6DEEF0, 0x03607C),
                new(0x715078, 0x035AC4),
                new(0x74AB40, 0x03607C),
                new(0x780CC8, 0x035AC4),
                new(0x7B6790, 0x03607C),
                new(0x7EC918, 0x035AC4),
                new(0x8223E0, 0x03607C),
                new(0x858460, 0x2684D4)
            }),
            new("personal.dat", PERSONAL_SAVE_SIZE, new FileHashRegion[]
            {
                new(0x00108, 0x35AC4),
                new(0x35BD0, 0x3607C)
            }),
            new("postbox.dat", POSTBOX_SAVE_SIZE, new FileHashRegion[]
            {
                new(0x000100, 0xB4447C)
            }),
            new("photo_studio_island.dat", PHOTO_STUDIO_ISLAND_SIZE, new FileHashRegion[]
            {
                new(0x000100, 0x262B0)
            }),
            new("profile.dat", PROFILE_SIZE, new FileHashRegion[]
            {
                new(0x000100, 0x69404)
            }),
        });

        #endregion

        #region REVISION 1.1.0

        private const int REV_110_MAIN_SAVE_SIZE = 0xAC2AA0;
        private const int REV_110_PERSONAL_SAVE_SIZE = 0x6BED0;
        private const int REV_110_POSTBOX_SAVE_SIZE = 0xB44590;
        private const int REV_110_PHOTO_STUDIO_ISLAND_SIZE = 0x263C0;
        private const int REV_110_PROFILE_SIZE = 0x69560;

        public static readonly FileHashInfo REV_110 = new(new FileHashDetails[]
        {
            new("main.dat", REV_110_MAIN_SAVE_SIZE, new FileHashRegion[]
            {
                new(0x000110, 0x1D6D5C),
                new(0x1D6E70, 0x323C0C),
                new(0x4FAB90, 0x035AFC),
                new(0x530690, 0x0362BC),
                new(0x566A60, 0x035AFC),
                new(0x59C560, 0x0362BC),
                new(0x5D2930, 0x035AFC),
                new(0x608430, 0x0362BC),
                new(0x63E800, 0x035AFC),
                new(0x674300, 0x0362BC),
                new(0x6AA6D0, 0x035AFC),
                new(0x6E01D0, 0x0362BC),
                new(0x7165A0, 0x035AFC),
                new(0x74C0A0, 0x0362BC),
                new(0x782470, 0x035AFC),
                new(0x7B7F70, 0x0362BC),
                new(0x7EE340, 0x035AFC),
                new(0x823E40, 0x0362BC),
                new(0x85A100, 0x26899C)
            }),
            new("personal.dat", REV_110_PERSONAL_SAVE_SIZE, new FileHashRegion[]
            {
                new(0x00110, 0x35AFC),
                new(0x35C10, 0x362BC)
            }),
            new("postbox.dat", REV_110_POSTBOX_SAVE_SIZE, new FileHashRegion[]
            {
                new(0x000100, 0xB4448C)
            }),
            new("photo_studio_island.dat", REV_110_PHOTO_STUDIO_ISLAND_SIZE, new FileHashRegion[]
            {
                new(0x000100, 0x262BC)
            }),
            new("profile.dat", REV_110_PROFILE_SIZE, new FileHashRegion[]
            {
                new(0x000100, 0x6945C)
            }),
        });

        #endregion

        #region REVISION 1.2.0

        private const int REV_120_MAIN_SAVE_SIZE = 0xACECD0;
        private const int REV_120_PERSONAL_SAVE_SIZE = 0x6D6C0;
        private const int REV_120_POSTBOX_SAVE_SIZE = REV_110_POSTBOX_SAVE_SIZE;
        private const int REV_120_PHOTO_STUDIO_ISLAND_SIZE = 0x2C9C0;
        private const int REV_120_PROFILE_SIZE = REV_110_PROFILE_SIZE;

        public static readonly FileHashInfo REV_120 = new(new FileHashDetails[]
        {
            new("main.dat", REV_120_MAIN_SAVE_SIZE, new FileHashRegion[]
            {
                new(0x000110, 0x1D6D5C),
                new(0x1D6E70, 0x323EBC),
                new(0x4FAE40, 0x035D2C),
                new(0x530B70, 0x03787C),
                new(0x568500, 0x035D2C),
                new(0x59E230, 0x03787C),
                new(0x5D5BC0, 0x035D2C),
                new(0x60B8F0, 0x03787C),
                new(0x643280, 0x035D2C),
                new(0x678FB0, 0x03787C),
                new(0x6B0940, 0x035D2C),
                new(0x6E6670, 0x03787C),
                new(0x71E000, 0x035D2C),
                new(0x753D30, 0x03787C),
                new(0x78B6C0, 0x035D2C),
                new(0x7C13F0, 0x03787C),
                new(0x7F8D80, 0x035D2C),
                new(0x82EAB0, 0x03787C),
                new(0x866330, 0x26899C)
            }),
            new("personal.dat", REV_120_PERSONAL_SAVE_SIZE, new FileHashRegion[]
            {
                new(0x00110, 0x35D2C),
                new(0x35E40, 0x3787C)
            }),
            new("postbox.dat", REV_120_POSTBOX_SAVE_SIZE, new FileHashRegion[]
            {
                new(0x000100, 0xB4448C)
            }),
            new("photo_studio_island.dat", REV_120_PHOTO_STUDIO_ISLAND_SIZE, new FileHashRegion[]
            {
                new(0x000100, 0x2C8BC)
            }),
            new("profile.dat", REV_120_PROFILE_SIZE, new FileHashRegion[]
            {
                new(0x000100, 0x6945C)
            }),
        });

        #endregion

        #region REVISION 1.3.0

        private const int REV_130_MAIN_SAVE_SIZE = 0xACED80;
        private const int REV_130_PERSONAL_SAVE_SIZE = 0x6D6D0;
        private const int REV_130_POSTBOX_SAVE_SIZE = REV_110_POSTBOX_SAVE_SIZE;
        private const int REV_130_PHOTO_STUDIO_ISLAND_SIZE = REV_120_PHOTO_STUDIO_ISLAND_SIZE;
        private const int REV_130_PROFILE_SIZE = REV_110_PROFILE_SIZE;

        public static readonly FileHashInfo REV_130 = new(new FileHashDetails[]
        {
            new("main.dat", REV_130_MAIN_SAVE_SIZE, new FileHashRegion[]
            {
                new(0x000110, 0x1D6D5C),
                new(0x1D6E70, 0x323EEC),
                new(0x4FAE70, 0x035D2C),
                new(0x530BA0, 0x03788C),
                new(0x568540, 0x035D2C),
                new(0x59E270, 0x03788C),
                new(0x5D5c10, 0x035D2C),
                new(0x60B940, 0x03788C),
                new(0x6432E0, 0x035D2C),
                new(0x679010, 0x03788C),
                new(0x6B09B0, 0x035D2C),
                new(0x6E66E0, 0x03788C),
                new(0x71E080, 0x035D2C),
                new(0x753DB0, 0x03788C),
                new(0x78B750, 0x035D2C),
                new(0x7C1480, 0x03788C),
                new(0x7F8E20, 0x035D2C),
                new(0x82EB50, 0x03788C),
                new(0x8663E0, 0x26899C)
            }),
            new("personal.dat", REV_130_PERSONAL_SAVE_SIZE, new FileHashRegion[]
            {
                new(0x00110, 0x35D2C),
                new(0x35E40, 0x3788C)
            }),
            new("postbox.dat", REV_130_POSTBOX_SAVE_SIZE, new FileHashRegion[]
            {
                new(0x000100, 0xB4448C)
            }),
            new("photo_studio_island.dat", REV_130_PHOTO_STUDIO_ISLAND_SIZE, new FileHashRegion[]
            {
                new(0x000100, 0x2C8BC)
            }),
            new("profile.dat", REV_130_PROFILE_SIZE, new FileHashRegion[]
            {
                new(0x000100, 0x6945C)
            }),
        });

        #endregion

        #region REVISION 1.4.0

        private const int REV_140_MAIN_SAVE_SIZE = 0xB05790;
        private const int REV_140_PERSONAL_SAVE_SIZE = 0x74420;
        private const int REV_140_POSTBOX_SAVE_SIZE = REV_110_POSTBOX_SAVE_SIZE;
        private const int REV_140_PHOTO_STUDIO_ISLAND_SIZE = REV_120_PHOTO_STUDIO_ISLAND_SIZE;
        private const int REV_140_PROFILE_SIZE = REV_110_PROFILE_SIZE;

        public static readonly FileHashInfo REV_140 = new(new FileHashDetails[]
        {
            new("main.dat", REV_140_MAIN_SAVE_SIZE, new FileHashRegion[]
            {
                new(0x000110, 0x1d6d5c),
                new(0x1d6e70, 0x323f2c),
                new(0x4faeb0, 0x035d2c),
                new(0x530be0, 0x03e5dc),
                new(0x56f2d0, 0x035d2c),
                new(0x5a5000, 0x03e5dc),
                new(0x5e36f0, 0x035d2c),
                new(0x619420, 0x03e5dc),
                new(0x657b10, 0x035d2c),
                new(0x68d840, 0x03e5dc),
                new(0x6cbf30, 0x035d2c),
                new(0x701c60, 0x03e5dc),
                new(0x740350, 0x035d2c),
                new(0x776080, 0x03e5dc),
                new(0x7b4770, 0x035d2c),
                new(0x7ea4a0, 0x03e5dc),
                new(0x828b90, 0x035d2c),
                new(0x85e8c0, 0x03e5dc),
                new(0x89cea0, 0x2688ec)
            }),
            new("personal.dat", REV_140_PERSONAL_SAVE_SIZE, new FileHashRegion[]
            {
                new(0x00110, 0x35D2C),
                new(0x35E40, 0x3E5DC)
            }),
            new("postbox.dat", REV_140_POSTBOX_SAVE_SIZE, new FileHashRegion[]
            {
                new(0x000100, 0xB4448C)
            }),
            new("photo_studio_island.dat", REV_140_PHOTO_STUDIO_ISLAND_SIZE, new FileHashRegion[]
            {
                new(0x000100, 0x2C8BC)
            }),
            new("profile.dat", REV_140_PROFILE_SIZE, new FileHashRegion[]
            {
                new(0x000100, 0x6945C)
            }),
        });

        #endregion

        #region REVISION 1.5.0

        private const int REV_150_MAIN_SAVE_SIZE = 0xB20750;
        private const int REV_150_PERSONAL_SAVE_SIZE = 0x76390;
        private const int REV_150_POSTBOX_SAVE_SIZE = REV_110_POSTBOX_SAVE_SIZE;
        private const int REV_150_PHOTO_STUDIO_ISLAND_SIZE = REV_120_PHOTO_STUDIO_ISLAND_SIZE;
        private const int REV_150_PROFILE_SIZE = REV_110_PROFILE_SIZE;

        public static readonly FileHashInfo REV_150 = new(new FileHashDetails[]
        {
            new("main.dat", REV_150_MAIN_SAVE_SIZE, new FileHashRegion[]
            {
                new(0x000110, 0x1e215c),
                new(0x1e2270, 0x323f6c),
                new(0x5062f0, 0x03693c),
                new(0x53cc30, 0x03f93c),
                new(0x57c680, 0x03693c),
                new(0x5b2fc0, 0x03f93c),
                new(0x5f2a10, 0x03693c),
                new(0x629350, 0x03f93c),
                new(0x668da0, 0x03693c),
                new(0x69f6e0, 0x03f93c),
                new(0x6df130, 0x03693c),
                new(0x715a70, 0x03f93c),
                new(0x7554c0, 0x03693c),
                new(0x78be00, 0x03f93c),
                new(0x7cb850, 0x03693c),
                new(0x802190, 0x03f93c),
                new(0x841be0, 0x03693c),
                new(0x878520, 0x03f93c),
                new(0x8b7e60, 0x2688ec)
            }),
            new("personal.dat", REV_150_PERSONAL_SAVE_SIZE, new FileHashRegion[]
            {
                new(0x00110, 0x3693c),
                new(0x36a50, 0x3f93c)
            }),
            new("postbox.dat", REV_150_POSTBOX_SAVE_SIZE, new FileHashRegion[]
            {
                new(0x000100, 0xB4448C)
            }),
            new("photo_studio_island.dat", REV_150_PHOTO_STUDIO_ISLAND_SIZE, new FileHashRegion[]
            {
                new(0x000100, 0x2C8BC)
            }),
            new("profile.dat", REV_150_PROFILE_SIZE, new FileHashRegion[]
            {
                new(0x000100, 0x6945C)
            }),
        });

        #endregion

        #region REVISION 1.6.0

        private const int REV_160_MAIN_SAVE_SIZE = 0xB258E0;
        private const int REV_160_PERSONAL_SAVE_SIZE = 0x76CF0;
        private const int REV_160_POSTBOX_SAVE_SIZE = REV_110_POSTBOX_SAVE_SIZE;
        private const int REV_160_PHOTO_STUDIO_ISLAND_SIZE = REV_120_PHOTO_STUDIO_ISLAND_SIZE;
        private const int REV_160_PROFILE_SIZE = REV_110_PROFILE_SIZE;

        public static readonly FileHashInfo REV_160 = new(new FileHashDetails[]
        {
            new("main.dat", REV_160_MAIN_SAVE_SIZE, new FileHashRegion[]
            {
                new(0x000110, 0x1e215c),
                new(0x1e2270, 0x32403c),
                new(0x5063c0, 0x03693c),
                new(0x53cd00, 0x04029c),
                new(0x57d0b0, 0x03693c),
                new(0x5b39f0, 0x04029c),
                new(0x5f3da0, 0x03693c),
                new(0x62a6e0, 0x04029c),
                new(0x66aa90, 0x03693c),
                new(0x6a13d0, 0x04029c),
                new(0x6e1780, 0x03693c),
                new(0x7180c0, 0x04029c),
                new(0x758470, 0x03693c),
                new(0x78edb0, 0x04029c),
                new(0x7cf160, 0x03693c),
                new(0x805aa0, 0x04029c),
                new(0x845e50, 0x03693c),
                new(0x87c790, 0x04029c),
                new(0x8bca30, 0x268eac)
            }),
            new("personal.dat", REV_160_PERSONAL_SAVE_SIZE, new FileHashRegion[]
            {
                new(0x00110, 0x3693c),
                new(0x36a50, 0x4029c)
            }),
            new("postbox.dat", REV_160_POSTBOX_SAVE_SIZE, new FileHashRegion[]
            {
                new(0x000100, 0xB4448C)
            }),
            new("photo_studio_island.dat", REV_160_PHOTO_STUDIO_ISLAND_SIZE, new FileHashRegion[]
            {
                new(0x000100, 0x2C8BC)
            }),
            new("profile.dat", REV_160_PROFILE_SIZE, new FileHashRegion[]
            {
                new(0x000100, 0x6945C)
            }),
        });

        #endregion
    }
}
