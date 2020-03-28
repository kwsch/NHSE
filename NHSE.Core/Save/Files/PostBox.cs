namespace NHSE.Core
{
    /// <summary>
    /// postbox.dat
    /// </summary>
    public sealed class PostBox : EncryptedFilePair
    {
        public PostBox(string folder) : base(folder, "postbox") { }
    }
}