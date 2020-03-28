namespace NHSE.Core
{
    /// <summary>
    /// SEAD likely stands for Software Entertainment Analysis & Development
    /// </summary>
    internal sealed class SEADRandom
    {
        private readonly uint[] state = new uint[4];

        public SEADRandom(uint seedOne, uint seedTwo, uint seedThree, uint seedFour)
        {
            state[0] = seedOne;
            state[1] = seedTwo;
            state[2] = seedThree;
            state[3] = seedFour;
        }

        public SEADRandom(uint seed)
        {
            for (int i = 0; i < 4; i++)
            {
                state[i] = (uint)((0x6C078965 * (seed ^ (seed >> 30))) + i + 1);
                seed = state[i];
            }
        }

        public uint GetU32()
        {
            uint v1 = state[0] ^ (state[0] << 11);

            state[0] = state[1];
            state[1] = state[2];
            state[2] = state[3];
            return state[3] = v1 ^ (v1 >> 8) ^ state[3] ^ (state[3] >> 19);
        }

        public ulong GetU64()
        {
            uint v1 = state[0] ^ (state[0] << 11);
            uint v2 = state[1];
            uint v3 = v1 ^ (v1 >> 8) ^ state[3];

            state[0] = state[2];
            state[1] = state[3];
            state[2] = v3 ^ (state[3] >> 19);
            state[3] = v2 ^ (v2 << 11) ^ ((v2 ^ (v2 << 11)) >> 8) ^ state[2] ^ (v3 >> 19);
            return ((ulong)state[2] << 32) | state[3];
        }
    }
}
