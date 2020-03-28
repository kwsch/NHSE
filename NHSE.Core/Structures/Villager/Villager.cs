using System.Text;

namespace NHSE.Core
{
    public class Villager
    {
        public readonly byte[] Data;
        public Villager(byte[] data) => Data = data;

        public byte Species
        {
            get => Data[0];
            set => Data[0] = value;
        }

        public byte Variant
        {
            get => Data[1];
            set => Data[1] = value;
        }

        public VillagerPersonality Personality
        {
            get => (VillagerPersonality)Data[2];
            set => Data[2] = (byte)value;
        }

        public string CatchPhrase
        {
            get => GetString(0x10014, 2 * 12);
            set => GetBytes(value, 2 * 12).CopyTo(Data, 0x10014);
        }

        public override string ToString() => InternalName;
        public string InternalName => VillagerUtil.GetInternalVillagerName((VillagerSpecies) Species, Variant);
        public int Gender => ((int)Personality / 4) & 1; // 0 = M, 1 = F

        public string GetString(int offset, int maxLength)
        {
            var str = Encoding.Unicode.GetString(Data, offset, maxLength * 2);
            return StringUtil.TrimFromZero(str);
        }

        public static byte[] GetBytes(string value, int maxLength)
        {
            if (value.Length > maxLength)
                value = value.Substring(0, maxLength);
            else if (value.Length < maxLength)
                value = value.PadRight(maxLength, '\0');
            return Encoding.Unicode.GetBytes(value);
        }
    }
}