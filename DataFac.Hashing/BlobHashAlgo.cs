namespace DataFac.Hashing;

public enum BlobHashAlgo : byte
{
    None = 0,
    Sha256 = 1,
}

public static class HashingHelpers
{
    public static byte ToCharCode(this BlobHashAlgo algo)
    {
        return algo switch
        {
            BlobHashAlgo.Sha256 => (byte)'S',
            _ => (byte)'N'
        };
    }

    public static BlobHashAlgo ToHashAlgo(this byte charCode)
    {
        return charCode switch
        {
            (byte)'S' => BlobHashAlgo.Sha256,
            _ => BlobHashAlgo.None,
        };
    }

}
