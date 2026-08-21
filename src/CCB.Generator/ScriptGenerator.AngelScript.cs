namespace CCB.Generator;

using System.Collections.Immutable;
using CCB.Generator.Model;
using CCB.Generator.Model.Bounded;
using CCB.Syntax;
using CCB.Syntax.Factory;

internal class AngelScriptGenerator(IndentedTextWriter writer, GenerateConfig config) : IDisposable
{
    public BoundTree WriteTree(Tree tree)
    {
        var ccbNamespace = new NamespaceType("ccb");
        var context = new GlobalContext(ccbNamespace);

        var onInitializeFunction = this.WriteOnInitializeFunction(context);
        writer.WriteLine();
        writer.WriteLine(BuildNamespace(ccbNamespace));
        writer.OpenBlock();

        var properties = this.WriteProperties(tree.Properties, context);
        var functions = this.WriteFunctions(tree.Functions, context);
        var classes = this.WriteClasses(tree.Classes, context);

        writer.CloseBlock();

        return new BoundTree(tree, onInitializeFunction, properties, functions, classes);
    }

    private BoundFunctionType WriteOnInitializeFunction(TypeContext context)
    {
        var onInitializeFunction = new FunctionType(ValueType.Void, "OnInitialize", []);

        var body = new[]
        {
            "load_ccb();",
        };

        return this.WriteFunctionCore(onInitializeFunction, context, body);
    }

    private ImmutableArray<BoundClassType> WriteClasses(ImmutableArray<ClassType> classes, TypeContext context)
    {
        var boundClasses = new List<BoundClassType>();

        foreach (var classType in classes)
        {
            writer.WriteLine();

            var classNamespace = new NamespaceType(classType.ClassName, context.Namespace);
            var classContext = new ClassContext(classType, classNamespace);

            writer.WriteLine(BuildNamespace(classNamespace));
            writer.OpenBlock();
            var boundProperties = this.WriteProperties(classType.Properties, classContext);
            var boundFunctions = this.WriteFunctions(classType.Methods, classContext);
            var iterator = this.WriteIterator(classType, classContext);
            writer.CloseBlock();

            var boundClass = new BoundClassType(classType, boundProperties, boundFunctions, iterator);

            boundClasses.Add(boundClass);
        }

        return [..boundClasses];
    }

    private BoundIteratorType? WriteIterator(ClassType classType, TypeContext context)
    {
        if (!config.Iterables.Contains(classType.ClassName))
        {
            return null;
        }

        context = new GlobalContext(context.Namespace);

        writer.WriteLine();
        var createIterator = this.WriteCreateIterator(classType, context);

        writer.WriteLine();
        var iteratorGet = this.WriteIteratorGet(classType, context);

        writer.WriteLine();
        var iteratorAdvance = this.WriteIteratorAdvance(classType, context);

        writer.WriteLine();
        var iteratorIsNull = this.WriteIteratorIsNull(classType, context);

        return new BoundIteratorType(createIterator, iteratorGet, iteratorAdvance, iteratorIsNull);
    }

    private BoundFunctionType WriteCreateIterator(ClassType classType, TypeContext context)
    {
        var iteratorType = new ValueType(GetIteratorName(classType), SyntaxKind.Identifier, SyntaxToken.None, SyntaxToken.None);
        var function = new FunctionType(iteratorType, "create_iterator", []);
        var body = $"return ::{classType.ClassName}::Iterator();";

        return this.WriteFunctionCore(function, context, body);
    }

    private BoundFunctionType WriteIteratorGet(ClassType classType, TypeContext context)
    {
        var iteratorType = new ValueType(GetIteratorName(classType),
            SyntaxKind.Identifier,
            SyntaxFactory.Token(SyntaxKind.Ampersand),
            SyntaxFactory.Token(SyntaxKind.In));
        var classValueType = new ValueType(classType.ClassName, SyntaxKind.Identifier, SyntaxToken.None, SyntaxToken.None);
        var function = new FunctionType(classValueType, "iterator_get", [new ParameterType("iterator", iteratorType, null)]);
        const string body = "return iterator.Get();";

        return this.WriteFunctionCore(function, context, body);
    }

    private BoundFunctionType WriteIteratorAdvance(ClassType classType, TypeContext context)
    {
        var iteratorType = new ValueType(GetIteratorName(classType),
            SyntaxKind.Identifier,
            SyntaxFactory.Token(SyntaxKind.Ampersand),
            SyntaxFactory.Token(SyntaxKind.In));
        var function = new FunctionType(ValueType.Void, "iterator_advance", [new ParameterType("iterator", iteratorType, null)]);
        const string body = "iterator++;";

        return this.WriteFunctionCore(function, context, body);
    }

    private BoundFunctionType WriteIteratorIsNull(ClassType classType, TypeContext context)
    {
        var iteratorType = new ValueType(GetIteratorName(classType),
            SyntaxKind.Identifier,
            SyntaxFactory.Token(SyntaxKind.Ampersand),
            SyntaxFactory.Token(SyntaxKind.In));
        var classValueType = new ValueType("bool", SyntaxKind.Bool, SyntaxToken.None, SyntaxToken.None);
        var function = new FunctionType(classValueType, "iterator_is_null", [new ParameterType("iterator", iteratorType, null)]);
        const string body = "return iterator == NULL;";

        return this.WriteFunctionCore(function, context, body);
    }

    private static string GetIteratorName(ClassType classType)
    {
        return $"{classType.ClassName}Iterator";
    }

    private ImmutableArray<BoundPropertyType> WriteProperties(ImmutableArray<PropertyType> properties, TypeContext context)
    {
        var boundProperties = new List<BoundPropertyType>(properties.Length);

        foreach (var property in properties)
        {
            writer.WriteLine();

            var boundProperty = this.WriteProperty(property, context);

            boundProperties.Add(boundProperty);
        }

        return [.. boundProperties];
    }

    private BoundPropertyType WriteProperty(PropertyType property, TypeContext context)
    {
        var getter = this.WriteGetter(property, context);

        if (property.IsConst)
        {
            return new BoundPropertyType(property, getter, null);
        }

        writer.WriteLine();

        var setter = this.WriteSetter(property, context);

        return new BoundPropertyType(property, getter, setter);
    }

    private BoundFunctionType WriteGetter(PropertyType property, TypeContext context)
    {
        var getter = new FunctionType(property.Type, $"Get{property.Name}", []);
        var body = $"return {GetPropertyAccessText(property, context)};";

        return this.WriteFunctionCore(getter, context, body);
    }

    private BoundFunctionType WriteSetter(PropertyType property, TypeContext context)
    {
        var value = new ParameterType("value", property.Type, null);
        var setter = new FunctionType(ValueType.Void, $"Set{property.Name}", [value]);
        var body = $"{GetPropertyAccessText(property, context)} = value;";

        return this.WriteFunctionCore(setter, context, body);
    }

    private ImmutableArray<BoundFunctionType> WriteFunctions(ImmutableArray<FunctionType> functions, TypeContext context)
    {
        var boundFunctions = new List<BoundFunctionType>(functions.Length);

        foreach (var function in functions)
        {
            writer.WriteLine();

            var boundFunction = this.WriteFunction(function, context);

            boundFunctions.Add(boundFunction);
        }

        return [..boundFunctions];
    }

    private BoundFunctionType WriteFunction(FunctionType function, TypeContext context)
    {
        return this.WriteFunctionCore(function, context, BuildFunctionBody(function, context));
    }

    private BoundFunctionType WriteFunctionCore(FunctionType function, TypeContext context, IEnumerable<string> body)
    {
        writer.WriteLine(BuildFunctionDeclaration(function, context, includeNamespace: false));
        writer.OpenBlock();

        foreach (var line in body)
        {
            writer.WriteLine(line);
        }

        writer.CloseBlock();

        var qualifiedDeclaration = BuildFunctionDeclaration(function, context, includeNamespace: true);
        return new BoundFunctionType(function, qualifiedDeclaration);
    }

    private BoundFunctionType WriteFunctionCore(FunctionType function, TypeContext context, params string[] body)
    {
        return this.WriteFunctionCore(function, context, body.AsEnumerable());
    }

    private static string BuildFunctionDeclaration(FunctionType function, TypeContext context, bool includeNamespace)
    {
        var namespacePrefix = includeNamespace ? GetNamespaceText(context.Namespace) : string.Empty;
        var parameters = BuildDeclarationParameterList(function, context);
        return $"{GetReturnTypeText(function.ReturnType)} {namespacePrefix}{function.Name}({parameters})";
    }

    private static string BuildFunctionBody(FunctionType function, TypeContext context)
    {
        var arguments = BuildCallArgumentList(function);

        var call = $"{GetFunctionAccessText(function, context)}({arguments})";
        return function.ReturnType.Kind is SyntaxKind.Void ? $"{call};" : $"return {call};";
    }

    private static string BuildDeclarationParameterList(FunctionType function, TypeContext context)
    {
        var parameterTexts = function.Parameters.Select(GetParameterText);
        return JoinWithThis(parameterTexts, context, GetThisParameterText);
    }

    private static string BuildCallArgumentList(FunctionType function)
    {
        var argumentTexts = function.Parameters.Select(GetArgumentText);
        return CommaJoin(argumentTexts);
    }

    private static string BuildNamespace(NamespaceType namespaceType)
    {
        return $"namespace {namespaceType.Name}";
    }

    private static string JoinWithThis(IEnumerable<string> texts, TypeContext context, Func<ClassType, string> thisTextProvider)
    {
        var allTexts = context switch
        {
            GlobalContext => texts,
            ClassContext classContext => texts.Prepend(thisTextProvider(classContext.Type)),
            _ => throw new ArgumentOutOfRangeException(nameof(context)),
        };
        return CommaJoin(allTexts);
    }

    private static string CommaJoin(IEnumerable<string?> values)
    {
        return string.Join(", ", values);
    }

    private static string CommaJoin(params string?[] values)
    {
        return CommaJoin(values.AsEnumerable());
    }

    private static string GetPropertyAccessText(PropertyType property, TypeContext context) => context switch
    {
        GlobalContext => property.Name,
        ClassContext => $"this.{property.Name}",
        _ => throw new ArgumentOutOfRangeException(nameof(context)),
    };

    private static string GetFunctionAccessText(FunctionType function, TypeContext context) => context switch
    {
        GlobalContext => $"::{function.Name}",
        ClassContext => $"this.{function.Name}",
        _ => throw new ArgumentOutOfRangeException(nameof(context)),
    };

    private static string GetArgumentText(ParameterType parameter) => parameter.Name;

    private static string GetParameterText(ParameterType parameter) =>
        $"{GetParameterTypeText(parameter.Type)} {parameter.Name}";

    private static string GetThisParameterText(ClassType classType) => $"{classType.ClassName} this";

    private static string GetNamespaceText(NamespaceType namespaceType)
    {
        return (namespaceType.Parent is null ? string.Empty : GetNamespaceText(namespaceType.Parent)) + namespaceType.Name + "::";
    }

    private static string GetReturnTypeText(ValueType type) => type.Kind switch
    {
        SyntaxKind.String => "char",
        _ => GetTypeText(type, NamespaceType.Global),
    };

    private static string GetParameterTypeText(ValueType type) => type.Kind switch
    {
        SyntaxKind.String => "const char",
        SyntaxKind.QuestionMark => "ref@",
        _ => GetTypeText(type, NamespaceType.Global),
    };

    private static string GetTypeText(ValueType type, NamespaceType namespaceType)
    {
        var namespaceText = type.Kind == SyntaxKind.Identifier ? GetNamespaceText(namespaceType) : string.Empty;

        return $"{namespaceText}{type.Name}{GetTypeModifiersText(type)}";
    }

    private static string GetTypeModifiersText(ValueType type)
    {
        var tokens = new[] { type.RefHandleToken, type.InoutToken };
        var modifierTexts = tokens.Where(token => token.Kind != SyntaxKind.None).Select(token => token.Text);
        return string.Join(' ', modifierTexts);
    }

    public void Dispose()
    {
        writer.Dispose();
    }
}