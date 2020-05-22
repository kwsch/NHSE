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
        [Fact] public void MarshalGSaveDateMD() => MarshalBytesTestS<GSaveDateMD>(GSaveDateMD.SIZE);
        [Fact] public void MarshalGSavePlayerId() => MarshalBytesTestS<GSavePlayerId>(GSavePlayerId.SIZE);
        [Fact] public void MarshalGSaveLandId() => MarshalBytesTestS<GSaveLandId>(GSaveLandId.SIZE);
        [Fact] public void MarshalGSavePlayerBaseId() => MarshalBytesTestS<GSavePlayerBaseId>(GSavePlayerBaseId.SIZE);
        [Fact] public void MarshalHandwriting() => MarshalBytesTestS<Handwriting>(Handwriting.SIZE);

        [Fact] public void MarshalGSaveRoomFloorWall() => MarshalBytesTestS<GSaveRoomFloorWall>(GSaveRoomFloorWall.SIZE);
        [Fact] public void MarshalGSaveAudioInfo() => MarshalBytesTestS<GSaveAudioInfo>(GSaveAudioInfo.SIZE);

        [Fact] public void MarshalGSaveManpu() => MarshalBytesTestS<GSavePlayerManpu>(GSavePlayerManpu.SIZE);
        [Fact] public void MarshalGSavePlayerHandleName() => MarshalBytesTestS<GSavePlayerHandleName>(GSavePlayerHandleName.SIZE);

        [Fact] public void MarshalGSaveFg() => MarshalBytesTest<GSaveFg>(GSaveFg.SIZE);
        [Fact] public void MarshalGSaveVisitorNpc() => MarshalBytesTest<GSaveVisitorNpc>(GSaveVisitorNpc.SIZE);

        [Fact] public void MarshalAchievementList() => MarshalBytesTestS<AchievementList>(AchievementList.SIZE);

        private static void MarshalBytesTestS<T>(int size) where T : struct
        {
            var bytes = new byte[size];
            var obj = bytes.ToStructure<T>();

            var decomputed = obj.ToBytes();
            decomputed.Length.Should().Be(size);
        }

        private static void MarshalBytesTest<T>(int size) where T : class
        {
            var bytes = new byte[size];
            var obj = bytes.ToClass<T>();

            var decomputed = obj.ToBytesClass();
            decomputed.Length.Should().Be(size);
        }
    }
}
