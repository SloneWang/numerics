namespace Slone.Numerics;

public unsafe static class ClassicBitOperations
{
    public static T Reverse<T>(T value)
        where T : unmanaged, IBinaryInteger<T>, IUnsignedNumber<T>
    {
        var size = sizeof(T);
        var binDigits = size << 3;
        var bytes = new byte[size];
        value.WriteBigEndian(bytes.AsSpan());
        var bits = new BitArray(bytes);
        var bin = new bool[binDigits];
        bits.CopyTo(bin, 0);
        bin
            .AsSpan()
            .Reverse();
        bits = new(bin);
        bits.CopyTo(bytes, 0);
        return T.ReadBigEndian(bytes, true);
    }
}
