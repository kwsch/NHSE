namespace NHSE.Core
{
    /// <summary>
    /// Provides information for hashing different revisions of the game's savedata.
    /// </summary>
    public static class FileHashRevision
    {
        private const string FN_MAIN = "main.dat";
        private const string FN_PERSONAL = "personal.dat";
        private const string FN_POSTBOX = "postbox.dat";
        private const string FN_PHOTO = "photo_studio_island.dat";
        private const string FN_PROFILE = "profile.dat";

        #region REVISION 1.0.0

        internal const int REV_100_MAIN = 0xAC0938;
        internal const int REV_100_PERSONAL = 0x6BC50;
        internal const int REV_100_POSTBOX = 0xB44580;
        internal const int REV_100_PHOTO = 0x263B4;
        internal const int REV_100_PROFILE = 0x69508;

        public static readonly FileHashInfo REV_100 = new(new FileHashDetails[]
        {
            new(FN_MAIN, REV_100_MAIN, new FileHashRegion[]
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
            new(FN_PERSONAL, REV_100_PERSONAL, new FileHashRegion[]
            {
                new(0x00108, 0x35AC4),
                new(0x35BD0, 0x3607C)
            }),
            new(FN_POSTBOX, REV_100_POSTBOX, new FileHashRegion[]
            {
                new(0x000100, 0xB4447C)
            }),
            new(FN_PHOTO, REV_100_PHOTO, new FileHashRegion[]
            {
                new(0x000100, 0x262B0)
            }),
            new(FN_PROFILE, REV_100_PROFILE, new FileHashRegion[]
            {
                new(0x000100, 0x69404)
            }),
        });

        #endregion

        #region REVISION 1.1.0

        internal const int REV_110_MAIN = 0xAC2AA0;
        internal const int REV_110_PERSONAL = 0x6BED0;
        internal const int REV_110_POSTBOX = 0xB44590;
        internal const int REV_110_PHOTO = 0x263C0;
        internal const int REV_110_PROFILE = 0x69560;

        public static readonly FileHashInfo REV_110 = new(new FileHashDetails[]
        {
            new(FN_MAIN, REV_110_MAIN, new FileHashRegion[]
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
            new(FN_PERSONAL, REV_110_PERSONAL, new FileHashRegion[]
            {
                new(0x00110, 0x35AFC),
                new(0x35C10, 0x362BC)
            }),
            new(FN_POSTBOX, REV_110_POSTBOX, new FileHashRegion[]
            {
                new(0x000100, 0xB4448C)
            }),
            new(FN_PHOTO, REV_110_PHOTO, new FileHashRegion[]
            {
                new(0x000100, 0x262BC)
            }),
            new(FN_PROFILE, REV_110_PROFILE, new FileHashRegion[]
            {
                new(0x000100, 0x6945C)
            }),
        });

        #endregion

        #region REVISION 1.2.0

        internal const int REV_120_MAIN = 0xACECD0;
        internal const int REV_120_PERSONAL = 0x6D6C0;
        internal const int REV_120_POSTBOX = REV_110_POSTBOX;
        internal const int REV_120_PHOTO = 0x2C9C0;
        internal const int REV_120_PROFILE = REV_110_PROFILE;

        public static readonly FileHashInfo REV_120 = new(new FileHashDetails[]
        {
            new(FN_MAIN, REV_120_MAIN, new FileHashRegion[]
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
            new(FN_PERSONAL, REV_120_PERSONAL, new FileHashRegion[]
            {
                new(0x00110, 0x35D2C),
                new(0x35E40, 0x3787C)
            }),
            new(FN_POSTBOX, REV_120_POSTBOX, new FileHashRegion[]
            {
                new(0x000100, 0xB4448C)
            }),
            new(FN_PHOTO, REV_120_PHOTO, new FileHashRegion[]
            {
                new(0x000100, 0x2C8BC)
            }),
            new(FN_PROFILE, REV_120_PROFILE, new FileHashRegion[]
            {
                new(0x000100, 0x6945C)
            }),
        });

        #endregion

        #region REVISION 1.3.0

        internal const int REV_130_MAIN = 0xACED80;
        internal const int REV_130_PERSONAL = 0x6D6D0;
        internal const int REV_130_POSTBOX = REV_110_POSTBOX;
        internal const int REV_130_PHOTO = REV_120_PHOTO;
        internal const int REV_130_PROFILE = REV_110_PROFILE;

        public static readonly FileHashInfo REV_130 = new(new FileHashDetails[]
        {
            new(FN_MAIN, REV_130_MAIN, new FileHashRegion[]
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
            new(FN_PERSONAL, REV_130_PERSONAL, new FileHashRegion[]
            {
                new(0x00110, 0x35D2C),
                new(0x35E40, 0x3788C)
            }),
            new(FN_POSTBOX, REV_130_POSTBOX, new FileHashRegion[]
            {
                new(0x000100, 0xB4448C)
            }),
            new(FN_PHOTO, REV_130_PHOTO, new FileHashRegion[]
            {
                new(0x000100, 0x2C8BC)
            }),
            new(FN_PROFILE, REV_130_PROFILE, new FileHashRegion[]
            {
                new(0x000100, 0x6945C)
            }),
        });

        #endregion

        #region REVISION 1.4.0

        internal const int REV_140_MAIN = 0xB05790;
        internal const int REV_140_PERSONAL = 0x74420;
        internal const int REV_140_POSTBOX = REV_110_POSTBOX;
        internal const int REV_140_PHOTO = REV_120_PHOTO;
        internal const int REV_140_PROFILE = REV_110_PROFILE;

        public static readonly FileHashInfo REV_140 = new(new FileHashDetails[]
        {
            new(FN_MAIN, REV_140_MAIN, new FileHashRegion[]
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
            new(FN_PERSONAL, REV_140_PERSONAL, new FileHashRegion[]
            {
                new(0x00110, 0x35D2C),
                new(0x35E40, 0x3E5DC)
            }),
            new(FN_POSTBOX, REV_140_POSTBOX, new FileHashRegion[]
            {
                new(0x000100, 0xB4448C)
            }),
            new(FN_PHOTO, REV_140_PHOTO, new FileHashRegion[]
            {
                new(0x000100, 0x2C8BC)
            }),
            new(FN_PROFILE, REV_140_PROFILE, new FileHashRegion[]
            {
                new(0x000100, 0x6945C)
            }),
        });

        #endregion

        #region REVISION 1.5.0

        internal const int REV_150_MAIN = 0xB20750;
        internal const int REV_150_PERSONAL = 0x76390;
        internal const int REV_150_POSTBOX = REV_110_POSTBOX;
        internal const int REV_150_PHOTO = REV_120_PHOTO;
        internal const int REV_150_PROFILE = REV_110_PROFILE;

        public static readonly FileHashInfo REV_150 = new(new FileHashDetails[]
        {
            new(FN_MAIN, REV_150_MAIN, new FileHashRegion[]
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
            new(FN_PERSONAL, REV_150_PERSONAL, new FileHashRegion[]
            {
                new(0x00110, 0x3693c),
                new(0x36a50, 0x3f93c)
            }),
            new(FN_POSTBOX, REV_150_POSTBOX, new FileHashRegion[]
            {
                new(0x000100, 0xB4448C)
            }),
            new(FN_PHOTO, REV_150_PHOTO, new FileHashRegion[]
            {
                new(0x000100, 0x2C8BC)
            }),
            new(FN_PROFILE, REV_150_PROFILE, new FileHashRegion[]
            {
                new(0x000100, 0x6945C)
            }),
        });

        #endregion

        #region REVISION 1.6.0

        internal const int REV_160_MAIN = 0xB258E0;
        internal const int REV_160_PERSONAL = 0x76CF0;
        internal const int REV_160_POSTBOX = REV_110_POSTBOX;
        internal const int REV_160_PHOTO = REV_120_PHOTO;
        internal const int REV_160_PROFILE = REV_110_PROFILE;

        public static readonly FileHashInfo REV_160 = new(new FileHashDetails[]
        {
            new(FN_MAIN, REV_160_MAIN, new FileHashRegion[]
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
            new(FN_PERSONAL, REV_160_PERSONAL, new FileHashRegion[]
            {
                new(0x00110, 0x3693c),
                new(0x36a50, 0x4029c)
            }),
            new(FN_POSTBOX, REV_160_POSTBOX, new FileHashRegion[]
            {
                new(0x000100, 0xB4448C)
            }),
            new(FN_PHOTO, REV_160_PHOTO, new FileHashRegion[]
            {
                new(0x000100, 0x2C8BC)
            }),
            new(FN_PROFILE, REV_160_PROFILE, new FileHashRegion[]
            {
                new(0x000100, 0x6945C)
            }),
        });

        #endregion

        #region REVISION 1.7.0

        internal const int REV_170_MAIN = 0x849C30; // reduced size
        internal const int REV_170_PERSONAL = 0x64140; // reduced size
        internal const int REV_170_POSTBOX = 0x47430; // reduced size
        internal const int REV_170_PHOTO = REV_120_PHOTO;
        internal const int REV_170_PROFILE = REV_110_PROFILE;

        public static readonly FileHashInfo REV_170 = new(new FileHashDetails[]
        {
            new(FN_MAIN, REV_170_MAIN, new FileHashRegion[]
            {
                new(0x000110, 0x1e215c),
                new(0x1e2270, 0x3221fc),
                new(0x504580, 0x03693c),
                new(0x53aec0, 0x02d6ec),
                new(0x5686c0, 0x03693c),
                new(0x59f000, 0x02d6ec),
                new(0x5cc800, 0x03693c),
                new(0x603140, 0x02d6ec),
                new(0x630940, 0x03693c),
                new(0x667280, 0x02d6ec),
                new(0x694a80, 0x03693c),
                new(0x6cb3c0, 0x02d6ec),
                new(0x6f8bc0, 0x03693c),
                new(0x72f500, 0x02d6ec),
                new(0x75cd00, 0x03693c),
                new(0x793640, 0x02d6ec),
                new(0x7c0e40, 0x03693c),
                new(0x7f7780, 0x02d6ec),
                new(0x824e70, 0x024dbc),
            }),
            new(FN_PERSONAL, REV_170_PERSONAL, new FileHashRegion[]
            {
                new(0x00110, 0x3693c),
                new(0x36a50, 0x2d6ec),
            }),
            new(FN_POSTBOX, REV_170_POSTBOX, new FileHashRegion[]
            {
                new(0x000100, 0x4732c)
            }),
            new(FN_PHOTO, REV_170_PHOTO, new FileHashRegion[]
            {
                new(0x000100, 0x2C8BC)
            }),
            new(FN_PROFILE, REV_170_PROFILE, new FileHashRegion[]
            {
                new(0x000100, 0x6945C)
            }),
        });

        #endregion

        #region REVISION 1.8.0 // Same as 1.7.0

        internal const int REV_180_MAIN = REV_170_MAIN;
        internal const int REV_180_PERSONAL = REV_170_PERSONAL;
        internal const int REV_180_POSTBOX = REV_170_POSTBOX;
        internal const int REV_180_PHOTO = REV_120_PHOTO;
        internal const int REV_180_PROFILE = REV_110_PROFILE;

        public static readonly FileHashInfo REV_180 = new(REV_170);

        #endregion

        #region REVISION 1.9.0

        internal const int REV_190_MAIN = 0x86D560;
        internal const int REV_190_PERSONAL = 0x64160;
        internal const int REV_190_POSTBOX = REV_170_POSTBOX;
        internal const int REV_190_PHOTO = REV_120_PHOTO;
        internal const int REV_190_PROFILE = REV_110_PROFILE;

        public static readonly FileHashInfo REV_190 = new(new FileHashDetails[]
        {
            new(FN_MAIN, REV_190_MAIN, new FileHashRegion[]
            {
                new(0x000110, 0x1e215c),
                new(0x1e2270, 0x34582c),
                new(0x527bb0, 0x03693c),
                new(0x55e4f0, 0x02d70c),
                new(0x58bd10, 0x03693c),
                new(0x5c2650, 0x02d70c),
                new(0x5efe70, 0x03693c),
                new(0x6267b0, 0x02d70c),
                new(0x653fd0, 0x03693c),
                new(0x68a910, 0x02d70c),
                new(0x6b8130, 0x03693c),
                new(0x6eea70, 0x02d70c),
                new(0x71c290, 0x03693c),
                new(0x752bd0, 0x02d70c),
                new(0x7803f0, 0x03693c),
                new(0x7b6d30, 0x02d70c),
                new(0x7e4550, 0x03693c),
                new(0x81ae90, 0x02d70c),
                new(0x8485a0, 0x024fbc),
            }),
            new(FN_PERSONAL, REV_190_PERSONAL, new FileHashRegion[]
            {
                new(0x00110, 0x3693c),
                new(0x36a50, 0x2d70c),
            }),
            new(FN_POSTBOX, REV_190_POSTBOX, new FileHashRegion[]
            {
                new(0x000100, 0x4732c)
            }),
            new(FN_PHOTO, REV_190_PHOTO, new FileHashRegion[]
            {
                new(0x000100, 0x2C8BC)
            }),
            new(FN_PROFILE, REV_190_PROFILE, new FileHashRegion[]
            {
                new(0x000100, 0x6945C)
            }),
        });

        #endregion

        #region REVISION 1.10.0

        internal const int REV_1100_MAIN = 0x86D570;
        internal const int REV_1100_PERSONAL = REV_190_PERSONAL;
        internal const int REV_1100_POSTBOX = REV_170_POSTBOX;
        internal const int REV_1100_PHOTO = 0x2C9D0;
        internal const int REV_1100_PROFILE = REV_110_PROFILE;

        public static readonly FileHashInfo REV_1100 = new(new FileHashDetails[]
        {
            new(FN_MAIN, REV_1100_MAIN, new FileHashRegion[]
            {
                new(0x000110, 0x1e216c),
                new(0x1e2280, 0x34582c),
                new(0x527bc0, 0x03693c),
                new(0x55e500, 0x02d70c),
                new(0x58bd20, 0x03693c),
                new(0x5c2660, 0x02d70c),
                new(0x5efe80, 0x03693c),
                new(0x6267c0, 0x02d70c),
                new(0x653fe0, 0x03693c),
                new(0x68a920, 0x02d70c),
                new(0x6b8140, 0x03693c),
                new(0x6eea80, 0x02d70c),
                new(0x71c2a0, 0x03693c),
                new(0x752be0, 0x02d70c),
                new(0x780400, 0x03693c),
                new(0x7b6d40, 0x02d70c),
                new(0x7e4560, 0x03693c),
                new(0x81aea0, 0x02d70c),
                new(0x8485b0, 0x024fbc),
            }),
            new(FN_PERSONAL, REV_1100_PERSONAL, new FileHashRegion[]
            {
                new(0x00110, 0x3693c),
                new(0x36a50, 0x2d70c),
            }),
            new(FN_POSTBOX, REV_1100_POSTBOX, new FileHashRegion[]
            {
                new(0x000100, 0x4732c)
            }),
            new(FN_PHOTO, REV_1100_PHOTO, new FileHashRegion[]
            {
                new(0x000100, 0x2c8cc)
            }),
            new(FN_PROFILE, REV_1100_PROFILE, new FileHashRegion[]
            {
                new(0x000100, 0x6945C)
            }),
        });

        #endregion
    }
}
