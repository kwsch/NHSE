using System;

namespace NHSE.Core;

/// <summary>
/// Offset info and object retrieval logic for <see cref="PostBox"/>
/// </summary>
public abstract class PostBoxOffsets
{
    public abstract int s_7b602b39 { get; }
    public abstract int MailList { get; }
    public abstract int FontTable { get; }
    public abstract int LatestUniqueId { get; }

    public static PostBoxOffsets GetOffsets(FileHeaderInfo Info)
    {
        var rev = Info.GetKnownRevisionIndex();
        return rev switch
        {
            0 => new PostBoxOffsets10(),
            1 => new PostBoxOffsets11(),
            2 => new PostBoxOffsets11(),
            3 => new PostBoxOffsets11(),
            4 => new PostBoxOffsets11(),
            5 => new PostBoxOffsets11(),
            6 => new PostBoxOffsets12(),
            7 => new PostBoxOffsets12(),
            8 => new PostBoxOffsets13(),
            9 => new PostBoxOffsets13(),
            10 => new PostBoxOffsets14(),
            11 => new PostBoxOffsets14(),
            12 => new PostBoxOffsets14(),
            13 => new PostBoxOffsets15(),
            14 => new PostBoxOffsets15(),
            15 => new PostBoxOffsets16(),
            16 => new PostBoxOffsets17(),
            17 => new PostBoxOffsets18(),
            18 => new PostBoxOffsets19(),
            19 => new PostBoxOffsets110(),
            20 => new PostBoxOffsets111(),
            21 => new PostBoxOffsets111(),
            22 => new PostBoxOffsets20(),
            23 => new PostBoxOffsets20(),
            24 => new PostBoxOffsets20(),
            25 => new PostBoxOffsets20(),
            26 => new PostBoxOffsets20(),
            27 => new PostBoxOffsets20(),
            28 => new PostBoxOffsets20(),
            29 => new PostBoxOffsets20(),
            30 => new PostBoxOffsets20(),
            31 => new PostBoxOffsets30(),
            _ => throw new IndexOutOfRangeException("Unknown revision!" + Environment.NewLine + Info),
        };
    }
}