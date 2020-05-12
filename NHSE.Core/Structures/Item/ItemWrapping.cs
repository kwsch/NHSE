namespace NHSE.Core
{
    public enum ItemWrapping : byte
    {
        Nothing = 0,
        WrappingPaper = 1,
        Present = 2,
        Delivery = 3
    }

    public enum ItemWrappingPaper : byte
    {
        Yellow = 00,
        Pink = 01,
        Orange = 02,
        LightGreen = 03,
        Green = 04,
        Mint = 05,
        LightBlue = 06,
        Purple = 07,
        Navy = 08,
        Blue = 09,
        White = 10,
        Red = 11,
        Gold = 12,
        Brown = 13,
        Gray = 14,
        Black = 15,
    }
}
