namespace NHSE.Core;

/// <summary>
/// Data structures stored for the HappyHomeDesigner DLC.
/// </summary>
public sealed class WhereAreN : EncryptedFilePair
{
    public const string FileName = "wherearen";

    public readonly WhereAreNOffsets Offsets;
    public WhereAreN(ISaveFileProvider provider) : base(provider, FileName) => Offsets = WhereAreNOffsets.GetOffsets(Info);

    public EncryptedInt32 Poki
    {
        get => EncryptedInt32.ReadVerify(Data, Offsets.Poki);
        set => value.Write(Data[Offsets.Poki..]);
    }
}