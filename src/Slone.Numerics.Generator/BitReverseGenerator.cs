namespace Slone.Numerics;

[type: Generator(LanguageNames.CSharp)]
public sealed partial class BitReverseGenerator : IIncrementalGenerator
{
    [property: GeneratedRegex(@"^(.+)(?=`\d+$)", RegexOptions.Compiled | RegexOptions.CultureInvariant)]
    private static partial Regex GenericTypeFriendlyNameRegex { get; } 

    public void Initialize(IncrementalGeneratorInitializationContext context)
        => context.RegisterSourceOutput(
            context.SyntaxProvider
                .ForAttributeWithMetadataName(
                    "Slone.Numerics.BitReverseAttribute",
                    static (node, token) => 
                        node is MethodDeclarationSyntax
                        {
                            Modifiers: not [] and var methodModifiers,
                            Parent: ClassDeclarationSyntax
                            {
                                Modifiers: not [] and var typeModifiers,
                            }
                        }
                        && methodModifiers.Any(SyntaxKind.StaticKeyword)
                        && methodModifiers.Any(SyntaxKind.PartialKeyword)
                        && typeModifiers.Any(SyntaxKind.StaticKeyword)
                        && typeModifiers.Any(SyntaxKind.PartialKeyword),
                    static (context, token) =>
                        context is
                        {
                            TargetSymbol: IMethodSymbol
                            {
                                ContainingType:
                                {
                                    ContainingNamespace: var @namespace,
                                    ContainingType: null,
                                    IsFileLocal: false,
                                    IsGenericType: false,
                                    IsStatic: true,
                                    MemberNames: var classMembers,
                                    Name: not "" and var className,
                                    TypeKind: TypeKind.Class,
                                },
                                DeclaredAccessibility: Accessibility.Public,
                                IsAsync: false,
                                IsConditional: false,
                                IsExtensionMethod: false,
                                IsExtern: false,
                                IsGenericMethod: false,
                                IsIterator: false,
                                IsPartialDefinition: true,
                                IsStatic: true,
                                IsVararg: false,
                                MethodKind: MethodKind.Ordinary,
                                Name: not "" and var methodName,
                                Parameters:
                                [
                                    {
                                        IsOptional: false,
                                        IsParams: false,
                                        IsThis: false,
                                        Name: not "" and var paramName,
                                        Ordinal: 0,
                                        RefKind: RefKind.None,
                                        ScopedKind: ScopedKind.None,
                                        Type: var paramType,
                                    },
                                ],
                                PartialImplementationPart: null,
                                ReturnsByRef: false,
                                ReturnsByRefReadonly: false,
                                ReturnsVoid: false,
                                ReturnType:
                                {
                                    IsNativeIntegerType: false,
                                    IsReadOnly: true,
                                    IsRefLikeType: false,
                                    IsTupleType: false,
                                    IsUnmanagedType: true,
                                    IsValueType: true,
                                    Name: var typeName,
                                    SpecialType: 
                                        (
                                            SpecialType.System_Byte
                                            or SpecialType.System_UInt16
                                            or SpecialType.System_UInt32
                                            or SpecialType.System_UInt64
                                        )
                                        and var specialType,
                                    TypeKind: TypeKind.Struct,
                                } returnType,
                            },
                        }
                        && paramType.Equals(returnType, SymbolEqualityComparer.IncludeNullability)
                        && !classMembers.Contains($"{typeName}LookupTable")
                        ? new BitReverseMethodMetadata(
                            @namespace?.ToDisplayString(), 
                            className, 
                            methodName, 
                            paramName, 
                            specialType switch
                            {
                                SpecialType.System_Byte => "byte",
                                SpecialType.System_UInt16 => "ushort",
                                SpecialType.System_UInt32 => "uint",
                                SpecialType.System_UInt64 => "ulong",
                                _ => typeName,
                            },
                            $"{typeName}LookupTable"
                        )
                        : null
                )
                .Where(static m => m is not null)
                .Select(static (m, token) => m!)
                .Collect(),
            static async (context, metadata) =>
            {
                foreach (var (@namespace, source) in metadata
                    .GroupBy(static m => m.Namespace)
                    .Select(static n =>
                    {
                        var builder = new StringBuilder();
                        builder.AppendLine($"// <auto-generated/>");
                        builder.AppendLine();
                        var global = string.IsNullOrEmpty(n.Key);
                        if (!global)
                        {
                            builder.AppendLine($"namespace {n.Key};");
                            builder.AppendLine();
                        }
                        foreach (var c in n.GroupBy(static m => m.Class))
                        {
                            builder.AppendLine($"static partial class {c.Key}");
                            builder.AppendLine($"{{");
                            foreach (var m in c)
                            {
                                unsafe static IEnumerable<string> GenerateLookupTable<T>()
                                    where T : unmanaged, IBinaryInteger<T>, IUnsignedNumber<T>
                                {
                                    var size = sizeof(T);
                                    var hexDigits = size << 1;
                                    var binDigits = size << 3;
                                    var length = int.Log2(binDigits) - 1;
                                    return Enumerable
                                        .Range(0, length)
                                        .Select(i =>
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
                                            return $"0x{value.ToString($"X{hexDigits}", CultureInfo.InvariantCulture)}";
                                        });
                                }
                                builder.AppendLine($"    [property: global::{typeof(CompilerGeneratedAttribute).FullName}]");
                                builder.AppendLine($"    private static global::{BitReverseGenerator.GenericTypeFriendlyNameRegex.Match(typeof(ReadOnlySpan<>).FullName!).Value}<{m.Type}> {m.Table}");
                                builder.AppendLine($"    {{");
                                builder.AppendLine($"        get =>");
                                builder.AppendLine($"        [");
                                foreach (var value in m.Type switch
                                    {
                                        "byte" => GenerateLookupTable<byte>(),
                                        "ushort" => GenerateLookupTable<ushort>(),
                                        "uint" => GenerateLookupTable<uint>(),
                                        "ulong" => GenerateLookupTable<ulong>(),
                                        _ => [],
                                    }
                                )
                                {
                                    builder.AppendLine($"            {value},");
                                }
                                builder.AppendLine($"        ];");
                                builder.AppendLine($"    }}");
                                builder.AppendLine();
                                builder.AppendLine($"    [method: global::{typeof(CompilerGeneratedAttribute).FullName}]");
                                builder.AppendLine($"    public static partial {m.Type} {m.Method}({m.Type} {m.Parameter})");
                                builder.AppendLine($"    {{");
                                builder.AppendLine($"        var table = {m.Class}.{m.Table};");
                                builder.AppendLine($"        var size = sizeof({m.Type});");
                                builder.AppendLine($"        var binDigits = size << 3;");
                                builder.AppendLine($"        var length = int.Log2(binDigits) - 1;");
                                builder.AppendLine($"        var i = 0;");
                                builder.AppendLine($"        var s = 1;");
                                builder.AppendLine($"        do");
                                builder.AppendLine($"        {{");
                                builder.AppendLine($"            {m.Parameter} = ({m.Type})((({m.Parameter} & ~table[i]) >> s) | (({m.Parameter} & table[i]) << s));");
                                builder.AppendLine($"            s <<= 1;");
                                builder.AppendLine($"        }} while (++i < length);");
                                builder.AppendLine($"        {m.Parameter} = ({m.Type})(({m.Parameter} >> s) | ({m.Parameter} << s));");
                                builder.AppendLine($"        return {m.Parameter};");
                                builder.AppendLine($"    }}");
                                builder.AppendLine();
                            }
                            builder.AppendLine($"}}");
                        }
                        var @namespace = global ? "global" : n.Key;
                        return (@namespace: @namespace, source: builder);
                    })
                )
                {
                    context.AddSource($"{@namespace}.BitReverse.g.cs", source.ToString());
                }
            }
        );
}

file record class BitReverseMethodMetadata
(
    string? Namespace,
    string Class,
    string Method,
    string Parameter,
    string Type,
    string Table
);
