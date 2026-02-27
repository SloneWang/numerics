namespace Slone.Numerics;

[type: ShortRunJob(RuntimeMoniker.Net10_0)]
[type: GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[type: CategoriesColumn]
[type: MemoryDiagnoser]
public class BitReverseBenchmark
{
    private readonly byte UInt8Value = TestCommon.CreateRandom<byte>();
    private readonly ushort UInt16Value = TestCommon.CreateRandom<ushort>();
    private readonly uint UInt32Value = TestCommon.CreateRandom<uint>();
    private readonly ulong UInt64Value = TestCommon.CreateRandom<ulong>();
    private readonly UInt128 UInt128Value = TestCommon.CreateRandom<UInt128>();

    [method: BenchmarkCategory("UInt8")]
    [method: Benchmark]
    public byte UInt8ReverseNormal()
    {
        return ClassicBitOperations.Reverse(this.UInt8Value);
    }

    [method: BenchmarkCategory("UInt8")]
    [method: Benchmark(Baseline = true)]
    public byte UInt8ReverseOptimized()
    {
        return BitOperations.Reverse(this.UInt8Value);
    }

    [method: BenchmarkCategory("UInt8")]
    [method: Benchmark]
    public byte UInt8ReverseGeneric()
    {
        return BitOperations.Reverse<byte>(this.UInt8Value);
    }

    [method: BenchmarkCategory("UInt16")]
    [method: Benchmark(Baseline = true)]
    public ushort UInt16ReverseNormal()
    {
        return ClassicBitOperations.Reverse(this.UInt16Value);
    }

    [method: BenchmarkCategory("UInt16")]
    [method: Benchmark]
    public ushort UInt16ReverseOptimized()
    {
        return BitOperations.Reverse(this.UInt16Value);
    }

    [method: BenchmarkCategory("UInt16")]
    [method: Benchmark]
    public ushort UInt16ReverseGeneric()
    {
        return BitOperations.Reverse<ushort>(this.UInt16Value);
    }

    [method: BenchmarkCategory("UInt32")]
    [method: Benchmark(Baseline = true)]
    public uint UInt32ReverseNormal()
    {
        return ClassicBitOperations.Reverse(this.UInt32Value);
    }

    [method: BenchmarkCategory("UInt32")]
    [method: Benchmark]
    public uint UInt32ReverseOptimized()
    {
        return BitOperations.Reverse(this.UInt32Value);
    }

    [method: BenchmarkCategory("UInt32")]
    [method: Benchmark]
    public uint UInt32ReverseGeneric()
    {
        return BitOperations.Reverse<uint>(this.UInt32Value);
    }

    [method: BenchmarkCategory("UInt64")]
    [method: Benchmark(Baseline = true)]
    public ulong UInt64ReverseNormal()
    {
        return ClassicBitOperations.Reverse(this.UInt64Value);
    }

    [method: BenchmarkCategory("UInt64")]
    [method: Benchmark]
    public ulong UInt64ReverseOptimized()
    {
        return BitOperations.Reverse(this.UInt64Value);
    }

    [method: BenchmarkCategory("UInt64")]
    [method: Benchmark]
    public ulong UInt64ReverseGeneric()
    {
        return BitOperations.Reverse<ulong>(this.UInt64Value);
    }

    [method: BenchmarkCategory("UInt128")]
    [method: Benchmark(Baseline = true)]
    public UInt128 UInt128ReverseNormal()
    {
        return ClassicBitOperations.Reverse(this.UInt128Value);
    }

    [method: BenchmarkCategory("UInt128")]
    [method: Benchmark]
    public UInt128 UInt128ReverseGeneric()
    {
        return BitOperations.Reverse<UInt128>(this.UInt128Value);
    }
}
