using FluentAssertions;
using NHSE.Injection;
using Xunit;

namespace NHSE.Tests
{
    public static class InjectionTests
    {
        [Fact]
        public static void VerifyItemBinary()
        {
            var data = Properties.Resources.itempacket;
            bool result = PocketInjector.ValidateItemBinary(data);
            result.Should().BeTrue();
        }
    }
}
