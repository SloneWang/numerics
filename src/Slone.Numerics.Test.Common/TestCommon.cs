namespace Slone.Numerics;

public unsafe static class TestCommon
{
    extension<T> (T value)
        where T : unmanaged, IBinaryInteger<T>, IUnsignedNumber<T>
    {
        public static T CreateRandom()
        {
            var data = new byte[sizeof(T)];
            RandomNumberGenerator.Fill(data);
            return T.ReadBigEndian(data, true);
        }

        public string ToBinaryString()
            => value.ToString($"B{sizeof(T) << 3}", CultureInfo.InvariantCulture);
    }
}
