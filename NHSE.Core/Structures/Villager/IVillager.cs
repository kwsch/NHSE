using System.Collections.Generic;

namespace NHSE.Core;

/// <summary>
/// Exposes all interact-able values for a villager.
/// </summary>
public interface IVillager : IVillagerOrigin
{
    byte Species { get; set; }
    byte Variant { get; set; }
    VillagerPersonality Personality { get; set; }
    string InternalName { get; }
    string CatchPhrase { get; set; }

    IReadOnlyList<VillagerItem> WearStockList { get; set; }
    IReadOnlyList<VillagerItem> FtrStockList { get; set; }

    byte BirthType { get; set; }
    byte InducementType { get; set; }
    byte MoveType { get; set; }
    bool MovingOut { get; set; }
    int Gender { get; }

    GSaveRoomFloorWall Room { get; set; }
    DesignPatternPRO Design { get; set; }

    public byte DIYEndHour { get; set; }
    public byte DIYEndMinute { get; set; }
    public byte DIYEndSecond { get; set; }
    public ushort DIYRecipeIndex { get; set; }

    GSaveMemory GetMemory(int index);
    GSaveMemory[] GetMemories();
    void SetMemory(GSaveMemory memory, int index);
    void SetMemories(IReadOnlyList<GSaveMemory> memories);

    ushort[] GetEventFlagsSave();
    void SetEventFlagsSave(ushort[] value);

    void SetFriendshipAll(byte value = byte.MaxValue);

    /// <summary> Returns the inner data buffer of the object, flushing any pending changes. </summary>
    byte[] Write();
    string Extension { get; }
}