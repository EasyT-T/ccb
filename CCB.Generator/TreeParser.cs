namespace CCB.Generator;

using System.Diagnostics;
using CCB.Generator.Model;
using CCB.Syntax;
using CCB.Syntax.Visitor;

internal class TreeParser : SimpleVisitor
{
    private Tree? _tree;

    private readonly List<FunctionType> _functions = [];

    private readonly List<PropertyType> _properties = [];

    private readonly List<ClassType> _classes = [];

    private readonly List<PropertyType> _classProperties = [];

    private readonly List<FunctionType> _classMethods = [];

    public Tree Parse(RootSyntax root)
    {
        if (this._tree is not null)
        {
            return this._tree;
        }

        root.Accept(this);

        this._tree = new Tree(
            Functions: [..this._functions],
            Properties: [..this._properties],
            Classes: [..this._classes]);

        this._functions.Clear();
        this._properties.Clear();
        this._classes.Clear();

        return this._tree;
    }

    public override void VisitRoot(RootSyntax root)
    {
        foreach (var member in root.Members)
        {
            member.Accept(this);
        }
    }

    public override void VisitGlobalProperty(GlobalPropertySyntax node)
    {
        var property = ParseCommonProperty(node.Type, node.Identifier, node.Modifiers);

        this._properties.Add(property);
    }

    public override void VisitFunctionDeclaration(FunctionDeclarationSyntax node)
    {
        var function = ParseCommonFunction(node.ReturnType, node.Identifier, node.ParameterList);

        this._functions.Add(function);
    }

    public override void VisitClassDeclaration(ClassDeclarationSyntax node)
    {
        foreach (var member in node.Members)
        {
            member.Accept(this);
        }

        var className = node.Identifier.Text;
        var classType = new ClassType(
            ClassName: className,
            PropertyTypes: [..this._classProperties],
            Methods: [..this._classMethods]);

        this._classes.Add(classType);
        this._classMethods.Clear();
        this._classProperties.Clear();
    }

    public override void VisitFieldDeclaration(FieldDeclarationSyntax node)
    {
        var property = ParseCommonProperty(node.Type, node.Identifier, node.Modifiers);

        this._classProperties.Add(property);
    }

    public override void VisitMethodDeclaration(MethodDeclarationSyntax node)
    {
        var function = ParseCommonFunction(node.ReturnType, node.Identifier, node.ParameterList);

        this._classMethods.Add(function);
    }

    private static PropertyType ParseCommonProperty(TypeSyntax typeSyntax, SyntaxToken identifier, SyntaxTokenList modifiers)
    {
        var name = identifier.Text;
        var type = ParseValueType(typeSyntax);
        var isConst = modifiers.Any(SyntaxKind.Const);

        return new PropertyType(
            Name: name,
            Type: type,
            IsConst: isConst);
    }

    private static FunctionType ParseCommonFunction(TypeSyntax returnType, SyntaxToken identifier, ParameterListSyntax parameterList)
    {
        var name = identifier.Text;
        var type = ParseValueType(returnType);
        var parameters = ParseParameters(parameterList);

        var function = new FunctionType(
            Name: name,
            ReturnType: type,
            Parameters: [..parameters]);

        return function;
    }

    private static List<ParameterType> ParseParameters(ParameterListSyntax node)
    {
        return [..node.Parameters.Select((parameterSyntax, i) => ParseParameter(parameterSyntax.Element, i))];
    }

    private static ParameterType ParseParameter(ParameterSyntax node, int index)
    {
        var name = string.IsNullOrEmpty(node.Identifier.Text) ? $"unnamed{index}" : node.Identifier.Text;

        var type = ParseValueType(node.Type);

        var defaultValue = GetDefaultValue(node.DefaultValue);

        return new ParameterType(
            Name: name,
            Type: type,
            DefaultValue: defaultValue);
    }

    private static ValueType ParseValueType(TypeSyntax typeSyntax)
    {
        var type = typeSyntax.Identifier.Text;
        var kind = typeSyntax.Identifier.Kind;
        var refHandleToken = typeSyntax.RefHandle;
        var inoutToken = typeSyntax.Inout;

        return new ValueType(
            Name: type,
            Kind: kind,
            RefHandleToken: refHandleToken,
            InoutToken: inoutToken);
    }

    private static object? GetDefaultValue(SyntaxToken token)
    {
        var rawText = token.Text;

        return token.Kind switch
        {
            SyntaxKind.Bool => rawText switch
            {
                "true" => Boxed.True,
                "false" => Boxed.False,
                _ => throw new UnreachableException(),
            },
            SyntaxKind.NumberLiteral => decimal.Parse(rawText),
            SyntaxKind.StringLiteral => rawText,
            _ => null,
        };
    }
}