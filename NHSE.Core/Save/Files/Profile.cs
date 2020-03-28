namespace NHSE.Core
{
    public sealed class Profile : EncryptedFilePair
    {
        public Profile(string folder) : base(folder, "profile") { }
    }
}