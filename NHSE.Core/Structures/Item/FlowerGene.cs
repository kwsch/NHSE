using System;

namespace NHSE.Core
{
    /// <summary>
    /// Genes that a Flower Item has
    /// </summary>
    [Flags]
    public enum FlowerGene : byte
    {
        None = 0,
        R1 = 1,
        R2 = 1 << 1,
        Y1 = 1 << 2,
        Y2 = 1 << 3,
        w1 = 1 << 4, // inverted; both bits on = no gene (not white)
        w2 = 1 << 5, // inverted; both bits on = no gene (not white)
        S1 = 1 << 6,
        S2 = 1 << 7,
    }
}
