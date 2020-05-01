using FluentAssertions;
using NHSE.Core;
using Xunit;

namespace NHSE.Tests
{
    public class FancyMarshalTests
    {
        [Fact] public void MarshalGSaveBulletinBoard() => MarshalBytesTestS<GSaveBulletinBoard>(GSaveBulletinBoard.SIZE);
        [Fact] public void MarshalBulletinBoard() => MarshalBytesTestS<BulletinBoardStock>(BulletinBoardStock.SIZE);
        [Fact] public void MarshalGSaveBBS() => MarshalBytesTestS<GSaveBBS>(GSaveBBS.SIZE);
        [Fact] public void MarshalGSaveDate() => MarshalBytesTestS<GSaveDate>(GSaveDate.SIZE);
        [Fact] public void MarshalGSavePlayerId() => MarshalBytesTestS<GSavePlayerId>(GSavePlayerId.SIZE);
        [Fact] public void MarshalGSaveLandId() => MarshalBytesTestS<GSaveLandId>(GSaveLandId.SIZE);
        [Fact] public void MarshalGSavePlayerBaseId() => MarshalBytesTestS<GSavePlayerBaseId>(GSavePlayerBaseId.SIZE);
        [Fact] public void MarshalHandwriting() => MarshalBytesTestS<Handwriting>(Handwriting.SIZE);

        private static void MarshalBytesTestS<T>(int size) where T : struct
        {
            var bytes = new byte[size];
            var obj = bytes.ToStructure<T>();

            var decomputed = obj.ToBytes();
            decomputed.Length.Should().Be(size);
        }
    }
}
