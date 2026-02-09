using System;

namespace NHSE.Core;

/// <summary>
/// <inheritdoc cref="PostBoxOffsets"/>
/// </summary>
public sealed class PostBoxOffsets11 : PostBoxOffsets
{
    // GSavePostBox
    private const int GSaveVersion = 0x0; // @0x0 size 0x100, align 4
    public override int s_7b602b39 => GSaveVersion + 0x100; // (_d35a9251) u32 "Code" size 0x4, align 4. In size 0x10 container
    public override int MailList => GSaveVersion + 0x110; // Beginning of mail list
    public override int FontTable => GSaveVersion + 0x46E60; // The forbidden alphabetti soup
    public override int LatestUniqueId => 0xb44580; // Next post index slot
}