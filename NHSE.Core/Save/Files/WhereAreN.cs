namespace NHSE.Core
{
    /// <summary>
    /// </summary>
    public sealed class WhereAreN : EncryptedFilePair
    {
        public readonly WhereAreNOffsets Offsets;
        public WhereAreN( string folder) : base(folder, "wherearen" ) => Offsets = WhereAreNOffsets.GetOffsets( Info );

        public EncryptedInt32 Poki
        {
            get => EncryptedInt32.ReadVerify( Data, Offsets.Poki );
            set => value.Write( Data, Offsets.Poki );
        }
    }
}