using DataFac.Hashing;
using System;

namespace DataFac.Compression;

public readonly struct CompressResult
{
    public readonly int InputSize;
    public readonly BlobHashAlgo HashAlgo;
    public readonly BlobCompAlgo CompAlgo;
    public readonly ReadOnlyMemory<byte> Output;
    public CompressResult(int inputSize, BlobHashAlgo hashAlgo, BlobCompAlgo compAlgo, ReadOnlyMemory<byte> output) : this()
    {
        InputSize = inputSize;
        HashAlgo = hashAlgo;
        CompAlgo = compAlgo;
        Output = output;
    }
}
