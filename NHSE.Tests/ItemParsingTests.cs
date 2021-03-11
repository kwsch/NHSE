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
        [InlineData("dal apron", 0x2F5E)]
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

        [Theory]
        [InlineData("royal Crown", 0x14BB)]
        [InlineData("royal crown (red)", 0x14BB)]
        [InlineData("bug aloha shirt ", 0x223C)]
        [InlineData("quaint painting", 0xA)]
        [InlineData("(none)", Item.NONE)]
        public static void ParseAssociatedItem(string nameNoParenthesis, ushort id)
        {
            var parse = ItemParser.GetItem(nameNoParenthesis);
            parse.ItemId.Should().Be(id);
        }

        private class ConfigWrapFake : IConfigItem
        {
            public bool WrapAllItems { get; } = true;
            public ItemWrappingPaper WrappingPaper { get; } = ItemWrappingPaper.Black;
            public bool SkipDropCheck { get; } = false;
        }
    }
}
