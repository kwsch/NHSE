using System.Linq;
using FluentAssertions;
using NHSE.Core;
using Xunit;

namespace NHSE.Tests
{
    public static class ItemParsingTests
    {
        [Theory]
        [InlineData("diner sofa", 0x102D)]
        [InlineData("? block", 0x35FD)]
        [InlineData("block", 0x35FE)]
        public static void ParseItem(string name, ushort id)
        {
            // single
            {
                // by name
                var parse = ItemParser.GetItem(name);
                parse.ItemId.Should().Be(id);
            }

            // many
            {
                var cfg = new ConfigWrapFake();
                var parse = ItemParser.GetItemsFromUserInput(name, cfg);
                parse.Count.Should().Be(1);
                parse.ToList()[0].ItemId.Should().Be(id);

                var hex = ItemParser.GetItemsFromUserInput(id.ToString("X8"), cfg);
                hex.Count.Should().Be(1);
                hex.ToList()[0].ItemId.Should().Be(id);
            }
        }

        private class ConfigWrapFake : IConfigItem
        {
            public bool WrapAllItems { get; } = true;
            public ItemWrappingPaper WrappingPaper { get; } = ItemWrappingPaper.Black;
        }
    }
}
