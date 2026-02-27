namespace Slone.Numerics;

[type: AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
internal sealed class BitReverseAttribute : Attribute;

public static partial class BitOperations
{
    [method: BitReverse]
    [method: OverloadResolutionPriority(4)]
    public static partial byte Reverse(byte value);

    [method: BitReverse]
    [method: OverloadResolutionPriority(3)]
    public static partial ushort Reverse(ushort value);

    [method: BitReverse]
    [method: OverloadResolutionPriority(2)]
    public static partial uint Reverse(uint value);

    [method: BitReverse]
    [method: OverloadResolutionPriority(1)]
    public static partial ulong Reverse(ulong value);

    [method: OverloadResolutionPriority(0)]
    public static T Reverse<T>(T value)
        where T : unmanaged, IBinaryInteger<T>, IUnsignedNumber<T>
        => BitOperations<T>.Reverse(value);
}

internal unsafe static class BitOperations<T>
    where T : unmanaged, IBinaryInteger<T>, IUnsignedNumber<T>
{
    private static ReadOnlyMemory<T> LookupTable { get; }

    static BitOperations()
    {
        var size = sizeof(T);
        var binDigits = size << 3;
        var length = int.Log2(binDigits) - 1;
        var table = new T[length];
        for (var i = 0; i < length; i++)
        {
            var mask = (T.One << (1 << i)) - T.One;
            var value = mask;
            var shift = 2 << i;
            var count = ((size << 2) >> i) - 1;
            for (var k = 0; k < count; k++)
            {
                value <<= shift;
                value |= mask;
            }
            table[i] = value;
        }
        BitOperations<T>.LookupTable = table;
    }

    public static T Reverse(T value)
    {
        var table = BitOperations<T>.LookupTable.Span;
        int size = sizeof(T);
        int binDigits = size << 3;
        int length = int.Log2(binDigits) - 1;
        var i = 0;
        var s = 1;
        do
        {
            value = ((value & ~table[i]) >> s) | ((value & table[i]) << s);
            s <<= 1;
        } while(++i < length);
        value = (value >> s) | (value << s);
        return value;
    }
}
