using System.Text;

namespace NHSE.Core
{
    public class ItemRemakeInfo
    {
        public readonly short Index;
        public readonly ushort ItemUniqueID;
        public readonly sbyte ReBodyPatternNum; // count of body colors

        public readonly byte[] ReBodyPatternColors0;
        public readonly byte[] ReBodyPatternColors1;

        public readonly byte[] ReFabricPatternColors0;
        public readonly byte[] ReFabricPatternColors1;

        public readonly bool ReFabricPattern0VisibleOff;

        public ItemRemakeInfo(short index, ushort id, sbyte count, byte[] bc0, byte[] bc1, byte[] fc0, byte[] fc1,
            bool fp0)
        {
            Index = index;
            ItemUniqueID = id;
            ReBodyPatternNum = count;

            ReBodyPatternColors0 = bc0;
            ReBodyPatternColors1 = bc1;

            ReFabricPatternColors0 = fc0;
            ReFabricPatternColors1 = fc1;

            ReFabricPattern0VisibleOff = fp0;
        }

        private const string Invalid = nameof(Invalid);

        public string GetColorDescription(int colorIndex)
        {
            var bc0 = ReBodyPatternColors0[colorIndex];
            var bc1 = ReBodyPatternColors1[colorIndex];
            if (bc0 == (byte) ItemCustomColor.None)
                return "Invalid";

            var c0 = ((ItemCustomColor)bc0).ToString();
            if (bc1 == (byte)ItemCustomColor.None || bc0 == bc1)
                return c0;

            var c1 = ((ItemCustomColor) bc1).ToString();

            return $"{c0}-{c1}";
        }

        public string GetColorSummary()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < 8; i++)
            {
                var cd = GetColorDescription(i);
                if (cd == Invalid)
                    continue;

                sb.Append(i).Append('=').AppendLine(cd);
            }
            return sb.ToString();
        }
    }
}
