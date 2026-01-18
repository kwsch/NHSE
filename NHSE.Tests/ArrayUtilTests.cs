using System;
using System.Collections.Generic;
using FluentAssertions;
using NHSE.Core;
using Xunit;

namespace NHSE.Tests;

public static class ArrayUtilTests
{
    [Fact]
    public static void ReplaceOccurrences_WhenPatternNotFound_ReturnsZero()
    {
        byte[] array = [0x01, 0x02, 0x03, 0x04, 0x05];
        byte[] pattern = [0xAA, 0xBB];
        byte[] swap = [0xCC, 0xDD];

        var count = array.ReplaceOccurrences(pattern, swap);

        count.Should().Be(0);
        array.Should().BeEquivalentTo([0x01, 0x02, 0x03, 0x04, 0x05]);
    }

    [Fact]
    public static void ReplaceOccurrences_WhenSingleOccurrence_ReplacesAndReturnsOne()
    {
        byte[] array = [0x01, 0xAA, 0xBB, 0x04, 0x05];
        byte[] pattern = [0xAA, 0xBB];
        byte[] swap = [0xCC, 0xDD];

        var count = array.ReplaceOccurrences(pattern, swap);

        count.Should().Be(1);
        array.Should().BeEquivalentTo([0x01, 0xCC, 0xDD, 0x04, 0x05]);
    }

    [Fact]
    public static void ReplaceOccurrences_WhenMultipleOccurrences_ReplacesAllAndReturnsCount()
    {
        byte[] array = [0xAA, 0xBB, 0x03, 0xAA, 0xBB, 0x06, 0xAA, 0xBB];
        byte[] pattern = [0xAA, 0xBB];
        byte[] swap = [0xCC, 0xDD];

        var count = array.ReplaceOccurrences(pattern, swap);

        count.Should().Be(3);
        array.Should().BeEquivalentTo([0xCC, 0xDD, 0x03, 0xCC, 0xDD, 0x06, 0xCC, 0xDD]);
    }

    [Fact]
    public static void ReplaceOccurrences_WhenConsecutiveOccurrences_ReplacesAll()
    {
        byte[] array = [0xAA, 0xBB, 0xAA, 0xBB, 0xAA, 0xBB];
        byte[] pattern = [0xAA, 0xBB];
        byte[] swap = [0xCC, 0xDD];

        var count = array.ReplaceOccurrences(pattern, swap);

        count.Should().Be(3);
        array.Should().BeEquivalentTo([0xCC, 0xDD, 0xCC, 0xDD, 0xCC, 0xDD]);
    }

    [Fact]
    public static void ReplaceOccurrences_WhenSwapContainsPattern_DoesNotCauseInfiniteLoop()
    {
        // Swap contains the original pattern - must skip past swapped data
        byte[] array = [0x01, 0xAA, 0xBB, 0x04];
        byte[] pattern = [0xAA, 0xBB];
        byte[] swap = [0xAA, 0xBB]; // Same as pattern

        var count = array.ReplaceOccurrences(pattern, swap);

        count.Should().Be(0);
        array.Should().BeEquivalentTo([0x01, 0xAA, 0xBB, 0x04]);
    }

    [Fact]
    public static void ReplaceOccurrences_WhenLargeFileWithRandomPlacements_ReplacesAllOccurrences()
    {
        const int fileSize = 1024 * 1024; // 1 MB
        const int sequenceLength = 0x13;  // 19 bytes
        const int seed = 42;

        var random = new Random(seed);
        Span<byte> file = new byte[fileSize];
        random.NextBytes(file);

        // Create two distinct random sequences
        Span<byte> patternA = stackalloc byte[sequenceLength];
        Span<byte> patternB = stackalloc byte[sequenceLength];
        random.NextBytes(patternA);
        random.NextBytes(patternB);

        // Ensure patterns are different
        patternB[0] = (byte)(patternA[0] ^ 0xFF);

        // Insert pattern A at random non-overlapping offsets
        var insertedOffsets = new List<int>();
        int currentPosition = 0;

        while (currentPosition + sequenceLength <= fileSize)
        {
            // Random gap between 0 and 1000 bytes, then add sequence length to avoid overlap
            int gap = random.Next(0, 1000);
            int nextOffset = currentPosition + gap;

            if (nextOffset + sequenceLength > fileSize)
                break;

            // Insert pattern A at this offset
            patternA.CopyTo(file[nextOffset..]);
            insertedOffsets.Add(nextOffset);

            // Move past the inserted sequence
            currentPosition = nextOffset + sequenceLength;
        }

        // Run the replacement
        var count = file.ReplaceOccurrences(patternA, patternB);

        // Verify count matches
        count.Should().Be(insertedOffsets.Count);

        // Verify each offset now contains pattern B
        foreach (var offset in insertedOffsets)
        {
            var actual = file.Slice(offset, sequenceLength);
            actual.SequenceEqual(patternB).Should().BeTrue(because: $"offset {offset} should have been replaced");
        }
    }
}
