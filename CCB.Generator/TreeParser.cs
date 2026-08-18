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

    public Tree Parse(RootSyntax root)
    {
        if (this._tree is not null)
        {
            return this._tree;
        }

        root.Accept(this);

        return this._tree = new Tree(
            functions: [..this._functions],
            properties: [..this._properties]);
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
        var name = node.Identifier.Text;
        var type = node.Type.Identifier.Text;

        var property = new PropertyType(
            className: null,
            name: name,
            type: type);

        this._properties.Add(property);
    }

    public override void VisitFunctionDeclaration(FunctionDeclarationSyntax node)
    {
        var name = node.Identifier.Text;
        var parameters = ParseParameters(node.ParameterList);

        var function = new FunctionType(
            className: null,
            name: name,
            parameters: [..parameters]);

        this._functions.Add(function);
    }

    public override void VisitClassDeclaration(ClassDeclarationSyntax node)
    {
        foreach (var member in node.Members)
        {
            member.Accept(this);
        }
    }

    public override void VisitFieldDeclaration(FieldDeclarationSyntax node)
    {
        var classNode = (ClassDeclarationSyntax)node.Parent!;
        var className = classNode.Identifier.Text;

        var name = node.Identifier.Text;
        var type = node.Type.Identifier.Text;

        var property = new PropertyType(
            className: className,
            name: name,
            type: type);

        this._properties.Add(property);
    }

    public override void VisitMethodDeclaration(MethodDeclarationSyntax node)
    {
        var classNode = (ClassDeclarationSyntax)node.Parent!;
        var className = classNode.Identifier.Text;

        var name = node.Identifier.Text;
        var parameters = ParseParameters(node.ParameterList);
        parameters.Insert(0, new ParameterType(
            name: GeneratorFacts.ThisVarName,
            type: className,
            defaultValue: null,
            isHandle: false,
            isRef: false,
            isIn: false,
            isOut: false));

        var function = new FunctionType(
            className: className,
            name: name,
            parameters: [.. parameters]);

        this._functions.Add(function);
    }

    private static List<ParameterType> ParseParameters(ParameterListSyntax node)
    {
        return [..node.Parameters.Select(parameterSyntax => ParseParameter(parameterSyntax.Element))];
    }

    private static ParameterType ParseParameter(ParameterSyntax node)
    {
        var name = node.Identifier.Text;
        var typeSyntax = node.Type;

        var type = typeSyntax.Identifier.Text;
        var isHandle = typeSyntax.IsHandle;
        var isRef = typeSyntax.IsRef;
        var isOut = typeSyntax.IsOut;
        var isIn = typeSyntax.IsIn;

        var defaultValue = GetDefaultValue(node.DefaultValue);

        return new ParameterType(
            name: name,
            type: type,
            defaultValue: defaultValue,
            isHandle: isHandle,
            isRef: isRef,
            isOut: isOut,
            isIn: isIn);
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