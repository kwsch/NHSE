using System.ComponentModel;
using System.Runtime.InteropServices;

namespace NHSE.Core
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    [TypeConverter(typeof(ValueTypeTypeConverter))]
    public struct GSavePlayerId
    {
        public const int SIZE = 0x38;
        public override string ToString() => $"{BaseId.Name}-{LandId.Name}";

        public GSaveLandId LandId { get; set; }
        public GSavePlayerBaseId BaseId { get; set; }
    }
}
