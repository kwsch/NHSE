using FluentAssertions;
using NHSE.Core;
using Xunit;

namespace NHSE.Tests
{
    public static class InjectionTests
    {
        [Fact]
        public static void VerifyItemBinary()
        {
            var data = Properties.Resources.itempacket;
            bool result = PlayerItemSet.ValidateItemBinary(data);
            result.Should().BeTrue();
        }
    }
}
