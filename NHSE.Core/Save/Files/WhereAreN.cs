namespace NHSE.Core;

/// <summary>
/// </summary>
public sealed class WhereAreN : EncryptedFilePair
{
    public const string FileName = "wherearen";

    public readonly WhereAreNOffsets Offsets;
    public WhereAreN(string folder) : base(folder, FileName) => Offsets = WhereAreNOffsets.GetOffsets(Info);

    public EncryptedInt32 Poki
    {
        get => EncryptedInt32.ReadVerify(Data, Offsets.Poki);
        set => value.Write(Data, Offsets.Poki);
    }
}