# Slone.Numerics
Additional .NET Numeric Algorithms

There is not a clear roadmap currently.

## Supported Frameworks
+ `.NET 10.0`

## APIs
+ `Slone.Numerics` *(namespace)*
    + `BitOperation` *(static class)*
        + `Reverse` *(static method)*:  
            + Description: to reverse the bit sequence expressing an unsigned integeer
            + Arguments:
                + `value`: an unsigned integeer with type `byte` `ushort` `uint` `ulong` or an unmanaged type `T` which implemented `IBinaryInteger<T>` `IUnsignedNumber<T>`
            + Returns: a reversed integeer with same type
            + Example: `Reverse((byte)0b1011_0100)` -> `0b0010_1101` 
