﻿using System.Drawing;

namespace NHSE.Core
{
    public static class AcreTileColor
    {
        public static readonly byte[] AcreTiles = ResourceUtil.GetBinaryResource("outside.bin");

        public static int GetAcreTileColor(ushort acre, int x, int y)
        {
            if (acre > (ushort)OutsideAcre.FldOutNGardenRFront00)
                return Color.Transparent.ToArgb();
            var baseOfs = acre * 32 * 32 * 4;

            // 64x64
            var shift = (4 * ((y * 64) + x));
            var ofs = baseOfs + shift;
            var tile = AcreTiles[ofs];
            return CollisionUtil.Dict[tile].ToArgb();
        }
    }
}
