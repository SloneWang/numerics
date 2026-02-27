namespace Slone.Numerics;

[type: TestClass]
public sealed class BitReverseTest
{
    [method: TestMethod]
    public void UInt8ReverseTest()
    {
        var value = byte.CreateRandom();
        var reverse0 = ClassicBitOperations.Reverse(value);
        var reverse1 = BitOperations.Reverse(value);
        var reverse2 = BitOperations.Reverse<byte>(value);
        Assert.AreEqual(reverse0, reverse1, "Test BitOperation.BitReverse", $"Expected: {reverse0.ToBinaryString()}", $"Actual: {reverse1.ToBinaryString()}");
        Assert.AreEqual(reverse0, reverse2, "Test BitOperation.BitReverse<T>", $"Expected: {reverse0.ToBinaryString()}", $"Actual: {reverse2.ToBinaryString()}");
    }

    [method: TestMethod]
    public void UInt16ReverseTest()
    {
        var value = ushort.CreateRandom();
        var reverse0 = ClassicBitOperations.Reverse(value);
        var reverse1 = BitOperations.Reverse(value);
        var reverse2 = BitOperations.Reverse<ushort>(value);
        Assert.AreEqual(reverse0, reverse1, "Test BitOperation.BitReverse", $"Expected: {reverse0.ToBinaryString()}", $"Actual: {reverse1.ToBinaryString()}");
        Assert.AreEqual(reverse0, reverse2, "Test BitOperation.BitReverse<T>", $"Expected: {reverse0.ToBinaryString()}", $"Actual: {reverse2.ToBinaryString()}");
    }

    [method: TestMethod]
    public void UInt32ReverseTest()
    {
        var value = uint.CreateRandom();
        var reverse0 = ClassicBitOperations.Reverse(value);
        var reverse1 = BitOperations.Reverse(value);
        var reverse2 = BitOperations.Reverse<uint>(value);
        Assert.AreEqual(reverse0, reverse1, "Test BitOperation.BitReverse", $"Expected: {reverse0.ToBinaryString()}", $"Actual: {reverse1.ToBinaryString()}");
        Assert.AreEqual(reverse0, reverse2, "Test BitOperation.BitReverse<T>", $"Expected: {reverse0.ToBinaryString()}", $"Actual: {reverse2.ToBinaryString()}");
    }

    [method: TestMethod]
    public void UInt64ReverseTest()
    {
        var value = ulong.CreateRandom();
        var reverse0 = ClassicBitOperations.Reverse(value);
        var reverse1 = BitOperations.Reverse(value);
        var reverse2 = BitOperations.Reverse<ulong>(value);
        Assert.AreEqual(reverse0, reverse1, "Test BitOperation.BitReverse", $"Expected: {reverse0.ToBinaryString()}", $"Actual: {reverse1.ToBinaryString()}");
        Assert.AreEqual(reverse0, reverse2, "Test BitOperation.BitReverse<T>", $"Expected: {reverse0.ToBinaryString()}", $"Actual: {reverse2.ToBinaryString()}");
    }

    [method: TestMethod]
    public void UInt128ReverseTest()
    {
        var value = UInt128.CreateRandom();
        var reverse0 = ClassicBitOperations.Reverse(value);
        var reverse2 = BitOperations.Reverse<UInt128>(value);
        Assert.AreEqual(reverse0, reverse2, "Test BitOperation.BitReverse<T>", $"Expected: {reverse0.ToBinaryString()}", $"Actual: {reverse2.ToBinaryString()}");
    }
}
