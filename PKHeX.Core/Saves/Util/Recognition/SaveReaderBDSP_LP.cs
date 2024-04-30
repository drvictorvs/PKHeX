using System;

namespace PKHeX.Core.Saves.Util.Recognition
{
    public sealed class SaveReaderGen8LP : ISaveReader
    {
        public bool IsRecognized(long size)
        {
            if (size is 979108)
                return true;
            else
                return false;
        }

        public SaveFile? ReadSaveFile(byte[] data, string? path = null)
        {
            var ver = (Gem8Version)System.Buffers.Binary.BinaryPrimitives.ReadUInt32LittleEndian(data);
            if (ver is (Gem8Version.V1_0 or Gem8Version.V1_1 or Gem8Version.V1_2 or Gem8Version.V1_3))
                throw new ArgumentOutOfRangeException(nameof(data), "Save file should be read as normal BDSP file.");
            var obj = new SAV8BS(data);
            return obj;
        }

        public SaveHandlerSplitResult? TrySplit(ReadOnlySpan<byte> input)
        {
            return null;
        }
    }
}
