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
        W1 = 1 << 4,
        W2 = 1 << 5,
        S1 = 1 << 6,
        S2 = 1 << 7,
    }
}
