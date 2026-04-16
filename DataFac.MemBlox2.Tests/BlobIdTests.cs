using Shouldly;
using System;
using System.Linq;
using Xunit;

namespace DataFac.MemBlox2.Tests;

public class BlobIdTests
{
    [Fact]
    public void BlobId02CreateWithZeroData()
    {
        ReadOnlySpan<byte> input = stackalloc byte[BlobIdV1.Size];
        BlobIdV1.ToDisplayString(input).ShouldBe("");
    }

    [Fact]
    public void BlobId03CreateWithInvalidData()
    {
        ReadOnlySpan<byte> input = Enumerable.Range(0, BlobIdV1.Size).Select(i => (byte)i).ToArray();
        BlobIdV1.ToDisplayString(input).ShouldBe("V2.3:185207048:U:N:ICEiIyQlJicoKSorLC0uLzAxMjM0NTY3ODk6Ozw9Pj8=");
    }

    [Fact]
    public void BlobId05CreateFromSpanWithValidData()
    {
        string inputStr =
            "00-00-01-00-00-01-00-00-00-01-00-00-00-00-00-00-" +
            "00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-" +
            "40-AF-F2-E9-D2-D8-92-2E-47-AF-D4-64-8E-69-67-49-" +
            "71-58-78-5F-BD-1D-A8-70-E7-11-02-66-BF-94-48-80";

        ReadOnlySpan<byte> input = inputStr.Split('-').Select(s => (byte)int.Parse(s, System.Globalization.NumberStyles.HexNumber)).ToArray();
        BlobIdV1.ToDisplayString(input).ShouldBe("V1.0:256:U:S:QK/y6dLYki5Hr9RkjmlnSXFYeF+9Hahw5xECZr+USIA=");
    }

    [Fact]
    public void BlobId07CreateFails()
    {
        var ex = Assert.ThrowsAny<ArgumentException>(() =>
        {
            ReadOnlySpan<byte> input = stackalloc byte[10];
            BlobIdV1.ReadNonEmbedded(input);
        });
        ex.Message.ShouldStartWith("Length must be 64 bytes");
    }

}

