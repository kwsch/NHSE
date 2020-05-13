using System.Collections.Generic;

namespace NHSE.Core
{
    public class PlayerRoom
    {
        public const int SIZE = 0x65C8;

        public readonly byte[] Data;
        public PlayerRoom(byte[] data) => Data = data;

        /*
          s_d8bc748b                        ItemLayerList[8];                          // @0x0 size 0xc80, align 4
          s_c20a4615                        ItemSwitchList[8];                         // @0x6400 size 0x34, align 4
          GSaveAudioInfo                    AudioInfo;                                 // @0x65a0 size 0x4, align 2
          GSaveRoomFloorWall                RoomFloorWall;                             // @0x65a4 size 0x24, align 4
         */

        public const int LayerCount = 8;
        public RoomItemLayer[] GetItemLayers() => RoomItemLayer.GetArray(Data.Slice(0, LayerCount * RoomItemLayer.SIZE));
        public void SetItemLayers(IReadOnlyList<RoomItemLayer> value) => RoomItemLayer.SetArray(value).CopyTo(Data, 0);

        public bool GetIsActive(int layer, int x, int y) => FlagUtil.GetFlag(Data, 0x6400 + (layer * 0x34), (y * 20) + x);
        public void SetIsActive(int layer, int x, int y, bool value = true) => FlagUtil.SetFlag(Data, 0x6400 + (layer * 0x34), (y * 20) + x, value);

        public GSaveAudioInfo AudioInfo
        {
            get => Data.Slice(0x65A0, GSaveAudioInfo.SIZE).ToStructure<GSaveAudioInfo>();
            set => value.ToBytes().CopyTo(Data, 0x65A0);
        }

        public GSaveRoomFloorWall RoomFloorWall
        {
            get => Data.Slice(0x65A4, GSaveRoomFloorWall.SIZE).ToStructure<GSaveRoomFloorWall>();
            set => value.ToBytes().CopyTo(Data, 0x65A4);
        }
    }
}
