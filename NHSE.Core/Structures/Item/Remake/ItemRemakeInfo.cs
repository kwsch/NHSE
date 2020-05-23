using System.Text;

namespace NHSE.Core
{
    /// <summary>
    /// Metadata for an item's customization permissions
    /// </summary>
    public class ItemRemakeInfo
    {
        public const int BodyColorCountMax = 8;

        public readonly short Index;
        public readonly ushort ItemUniqueID;
        public readonly sbyte ReBodyPatternNum; // count of body colors

        public readonly byte[] ReBodyPatternColors0;
        public readonly byte[] ReBodyPatternColors1;

        public readonly byte[] ReFabricPatternColors0;
        public readonly byte[] ReFabricPatternColors1;

        public readonly bool ReFabricPattern0VisibleOff;

        public ItemRemakeInfo(short index, ushort id, sbyte count, byte[] bc0, byte[] bc1, byte[] fc0, byte[] fc1, bool fp0)
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

        public bool HasBodyColor(int variant) => ReBodyPatternColors0[variant] != 14 || ReBodyPatternColors1[variant] != 14;
        public bool HasFabricColor(int variant) => ReFabricPatternColors0[variant] != 14 || ReFabricPatternColors1[variant] != 14;

        public string GetBodyDescription(int colorIndex, IRemakeString str)
        {
            if (str.BodyColor.TryGetValue($"{ItemUniqueID:00000}_{colorIndex}", out var color))
                return $"{color} ({GetBodyDescription(colorIndex)})";
            var c0 = ReBodyPatternColors0[colorIndex];
            var c1 = ReBodyPatternColors1[colorIndex];
            return GetColorText(c0, c1);
        }

        public string GetFabricDescription(int colorIndex, IRemakeString str)
        {
            if (str.FabricColor.TryGetValue($"{ItemUniqueID:00000}_{colorIndex}", out var color))
                return $"{color} ({GetBodyDescription(colorIndex)})";
            var c0 = ReFabricPatternColors0[colorIndex];
            var c1 = ReFabricPatternColors1[colorIndex];
            return GetColorText(c0, c1);
        }

        public string GetBodyDescription(int colorIndex)
        {
            var c0 = ReBodyPatternColors0[colorIndex];
            var c1 = ReBodyPatternColors1[colorIndex];
            return GetColorText(c0, c1);
        }

        public string GetFabricDescription(int colorIndex)
        {
            var c0 = ReFabricPatternColors0[colorIndex];
            var c1 = ReFabricPatternColors1[colorIndex];
            return GetColorText(c0, c1);
        }

        private static string GetColorText(byte c0, byte c1)
        {
            if (c0 == (byte) ItemCustomColor.None)
            {
                if (c1 == (byte) ItemCustomColor.None)
                    return "Invalid";
                return GetColorText(c1);
            }

            var s0 = GetColorText(c0);
            if (c1 == (byte) ItemCustomColor.None || c0 == c1)
                return s0;

            var s1 = GetColorText(c1);

            return $"{s0}-{s1}";
        }

        private static string GetColorText(byte value) => ((ItemCustomColor)value).ToString();

        public string GetBodySummary(IRemakeString str)
        {
            var sb = new StringBuilder();
            var item = $"{ItemUniqueID:00000}";
            if (str.BodyParts.TryGetValue(item, out var parts))
                sb.Append(parts).AppendLine(":");

            for (int i = 0; i < 8; i++)
            {
                var cd = GetBodyDescription(i);
                if (cd == Invalid)
                    continue;

                sb.Append(i).Append('=');

                var name = $"{ItemUniqueID:00000}_{i}";
                if (str.BodyColor.TryGetValue(name, out var desc))
                    sb.Append(desc).Append(" (").Append(cd).AppendLine(")");
                else
                    sb.AppendLine(cd);
            }
            return sb.ToString();
        }

        public string GetFabricSummary(IRemakeString str)
        {
            var sb = new StringBuilder();
            var item = $"{ItemUniqueID:00000}";
            if (str.FabricParts.TryGetValue(item, out var parts))
                sb.Append(parts).AppendLine(":");

            for (int i = 0; i < 8; i++)
            {
                var cd = GetFabricDescription(i);
                if (cd == Invalid)
                    continue;

                var shifted = (i << 5);
                sb.Append(shifted.ToString("000")).Append('=');
                var name = $"{ItemUniqueID:00000}_{i}";
                if (str.FabricColor.TryGetValue(name, out var desc))
                    sb.Append(desc).Append(" (").Append(cd).AppendLine(")");
                else
                    sb.AppendLine(cd);
            }
            return sb.ToString();
        }
    }
}
