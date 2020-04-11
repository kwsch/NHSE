using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NHSE.Parsing
{
    public class MSBT
	{
		public readonly MSBTHeader Header;
		public readonly LBL1 LBL1 = new LBL1();
		public readonly TXT2 TXT2 = new TXT2();
		public readonly Encoding FileEncoding;
		public readonly List<string> SectionOrder;
		public bool HasLabels;

		public MSBT(byte[] rawBytes)
		{
            using var stream = new MemoryStream(rawBytes);
            using var br = new BinaryReaderX(stream);

			Header = new MSBTHeader(br);
            FileEncoding = (Header.EncodingByte == MSBTEncodingByte.UTF8 ? Encoding.UTF8 : Encoding.Unicode);

			SectionOrder = new List<string>();
			for (int i = 0; i < Header.NumberOfSections; i++)
            {
                var peek = br.PeekString();
                switch (peek)
                {
                    case "LBL1":
                        ReadLBL1(br);
                        SectionOrder.Add("LBL1");
                        break;

                    case "ATR1":
                        // don't care
						br.ReadBytes(sizeof(uint) + sizeof(uint) + sizeof(long) + 1);
                        while (br.BaseStream.Position % 16 != 0 && br.BaseStream.Position != br.BaseStream.Length)
                            br.ReadByte();
                        SectionOrder.Add("ATR1");
						break;

					case "TXT2":
                        ReadTXT2(br);
                        SectionOrder.Add("TXT2");
                        break;
                }
            }

            br.Close();
        }

		private void ReadLBL1(BinaryReaderX br)
		{
			LBL1.Identifier = br.ReadString(4);
			LBL1.SectionSize = br.ReadUInt32();
			LBL1.Padding1 = br.ReadBytes(8);
			long startOfLabels = br.BaseStream.Position;
			LBL1.NumberOfGroups = br.ReadUInt32();

			for (int i = 0; i < LBL1.NumberOfGroups; i++)
			{
                var grp = new MSBTGroup
                {
                    NumberOfLabels = br.ReadUInt32(),
                    Offset = br.ReadUInt32()
                };
                LBL1.Groups.Add(grp);
			}

			foreach (var grp in LBL1.Groups)
			{
				br.BaseStream.Seek(startOfLabels + grp.Offset, SeekOrigin.Begin);

				for (int i = 0; i < grp.NumberOfLabels; i++)
				{
                    var length = Convert.ToUInt32(br.ReadByte());
					var name = br.ReadString((int)length);
					var index = br.ReadUInt32();
                    var lbl = new MSBTLabel(name) {Index = index, Length = length};
					LBL1.Labels.Add(lbl);
				}
			}

			if (LBL1.Labels.Count > 0)
				HasLabels = true;

			PaddingSeek(br);
		}

		private void ReadTXT2(BinaryReaderX br)
		{
			TXT2.Identifier = br.ReadString(4);
			TXT2.SectionSize = br.ReadUInt32();
			TXT2.Padding1 = br.ReadBytes(8);
			long startOfStrings = br.BaseStream.Position;
			TXT2.NumberOfStrings = br.ReadUInt32();

			var offsets = new List<uint>();
			for (int i = 0; i < TXT2.NumberOfStrings; i++)
				offsets.Add(br.ReadUInt32());

			for (int i = 0; i < TXT2.NumberOfStrings; i++)
			{
				uint nextOffset = (i + 1 < offsets.Count) ? ((uint)startOfStrings + offsets[i + 1]) : ((uint)startOfStrings + TXT2.SectionSize);

				br.BaseStream.Seek(startOfStrings + offsets[i], SeekOrigin.Begin);

				var result = new List<byte>();
				while (br.BaseStream.Position < nextOffset && br.BaseStream.Position < Header.FileSize)
				{
					if (Header.EncodingByte == MSBTEncodingByte.UTF8)
                    {
                        result.Add(br.ReadByte());
                    }
                    else
					{
						byte[] unichar = br.ReadBytes(2);

						if (br.ByteOrder == ByteOrder.BigEndian)
							Array.Reverse(unichar);

						result.AddRange(unichar);
					}
				}
                var str = new MSBTTextString(result.ToArray(), (uint)i);
                TXT2.Strings.Add(str);
			}

			// Tie in LBL1 labels
			foreach (var lbl in LBL1.Labels)
				lbl.String = TXT2.Strings[(int)lbl.Index];

			PaddingSeek(br);
		}

		private static void PaddingSeek(BinaryReader br)
		{
			long remainder = br.BaseStream.Position % 16;
            if (remainder <= 0)
                return;
            var _ = br.ReadByte();
            br.BaseStream.Seek(-1, SeekOrigin.Current);
            br.BaseStream.Seek(16 - remainder, SeekOrigin.Current);
        }
	}
}
