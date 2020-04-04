using FluentAssertions;
using NHSE.Core;
using Xunit;

namespace NHSE.Tests
{
    public class EncryptedIntTests
    {
        [Fact]
        public void TestParse()
        {
            const int expect = 31_280;
            byte[] data = {0x8A, 0xC4, 0xE3, 0xCF, 0x37, 0xD5, 0x1A, 0xD3};
            var val = EncryptedInt32.ReadVerify(data, 0);
            val.Value.Should().Be(expect);

            var encode = EncryptedInt32.Encrypt(expect, val.Shift, val.Adjust);
            val.OriginalEncrypted.Should().Be(encode);
        }
    }
}
