namespace NHSE.Core
{
    /// <summary>
    /// profile.dat
    /// </summary>
    public sealed class Profile : EncryptedFilePair
    {
        public Profile(string folder) : base(folder, "profile") { }

        // pretty much just a jpeg -- which is also stored in Personal.
    }
}