namespace NHSE.Core
{
    public sealed class PostBox : EncryptedFilePair
    {
        public PostBox(string folder) : base(folder, "postbox") { }
    }
}