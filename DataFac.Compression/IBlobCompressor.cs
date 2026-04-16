using System;

namespace DataFac.Compression;

public interface IBlobCompressor
{
#if NET7_0_OR_GREATER
    static abstract CompressResult CompressData(ReadOnlyMemory<byte> data, Span<byte> hashSpan, int maxEmbeddedSize);
    static abstract CompressResult CompressText(string text, Span<byte> hashSpan, int maxEmbeddedSize);
    static abstract ReadOnlyMemory<byte> Decompress(ReadOnlySpan<byte> compressed);
#endif
}
