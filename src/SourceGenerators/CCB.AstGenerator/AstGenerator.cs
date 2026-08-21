namespace CCB.AstGenerator;

using System;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using CCB.AstGenerator.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

[Generator]
public class AstGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        context.RegisterPostInitializationOutput(PostInitializationOutput);

        var nodes = context.SyntaxProvider.ForAttributeWithMetadataName(
            GeneratorFacts.SyntaxNodeAttributeFullQualifiedName,
            (node, _) => node is ClassDeclarationSyntax,
            (syntaxContext, _) => (Node: (ClassDeclarationSyntax)syntaxContext.TargetNode, Symbol: (INamedTypeSymbol)syntaxContext.TargetSymbol));

        context.RegisterSourceOutput(nodes.Combine(context.CompilationProvider), GenerateCode);
    }

    private static void PostInitializationOutput(IncrementalGeneratorPostInitializationContext context)
    {
        context.AddSource($"{GeneratorFacts.SyntaxNodeAttributeName}.g.cs", GeneratorFacts.SyntaxNodeAttributeCode);
        context.AddSource($"{GeneratorFacts.NodeSlotAttributeName}.g.cs", GeneratorFacts.NodeSlotAttributeCode);
    }

    private static void GenerateCode(SourceProductionContext context, ((ClassDeclarationSyntax Node, INamedTypeSymbol Symbol) Left, Compilation Right) source)
    {
        var node = source.Left.Node;
        var compilation = source.Right;
        var model = compilation.GetSemanticModel(node.SyntaxTree);

        if (!node.Modifiers.Any(SyntaxKind.PartialKeyword))
        {
            // TODO
            return;
        }

        var className = node.Identifier.ValueText + node.TypeParameterList;
        var baseClassName = node.BaseList?.Types.FirstOrDefault()?.Type.ToString();
        var inheritClassName = baseClassName is "GreenNode" or null ? "SyntaxNode" : baseClassName;

        var nodeAttributeSymbol = compilation.GetTypeByMetadataName(GeneratorFacts.NodeSlotAttributeFullQualifiedName);

        var properties = node.Members.OfType<PropertyDeclarationSyntax>().Where(p => p.Modifiers.Any(SyntaxKind.PublicKeyword));
        var propertyInfos = properties
            .Select(p =>
            {
                var propertySymbol = model.GetDeclaredSymbol(p);
                var isNullable = propertySymbol?.NullableAnnotation == NullableAnnotation.Annotated;

                var attribute = propertySymbol?
                    .GetAttributes()
                    .FirstOrDefault(a => SymbolEqualityComparer.Default.Equals(a.AttributeClass, nodeAttributeSymbol));

                var slot = (int?)attribute?.ConstructorArguments[0].Value;
                var isToken = (bool?)attribute?.ConstructorArguments[1].Value ?? false;
                var isTokenList = (bool?)attribute?.ConstructorArguments[2].Value ?? false;
                var isList = (bool?)attribute?.ConstructorArguments[3].Value ?? false;

                return (
                    Node: p,
                    Symbol: propertySymbol,
                    VarName: p.Identifier.ValueText.ToCamelCase(),
                    PropertyName: p.Identifier.ValueText,
                    TypeName: p.Type.ToString(),
                    Slot: slot,
                    IsToken: isToken,
                    IsTokenList: isTokenList,
                    IsList: isList,
                    IsNullable: isNullable);
            })
            .Where(i => i.Slot is not null)
            .OrderBy(i => i.Slot)
            .ToImmutableArray();

        var factoryName = className.EndsWith("Syntax", StringComparison.Ordinal)
            ? className.Substring(0, className.Length - "Syntax".Length)
            : className;

        var updateArgList = propertyInfos.Select(i => "this." + i.PropertyName).ToImmutableArray();
        var updateParamList = propertyInfos.Select(i => i.IsTokenList ? $"SyntaxTokenList {i.VarName}" : $"{i.TypeName} {i.VarName}").ToImmutableArray();

        var constructArgs = string.Join(", ", propertyInfos.Select(i => i.VarName));
        var factoryArgs = string.Join(", ", propertyInfos.Select(i => i.IsTokenList || i.IsList ? $"{i.VarName}.Node" : i.VarName).Prepend($"{GeneratorFacts.SyntaxNamespace}.SyntaxKind.{factoryName}"));
        var constructParams = string.Join(", ", propertyInfos.Select(i => i.IsTokenList || i.IsList ? $"GreenNode? {i.VarName}" : $"{i.TypeName} {i.VarName}").Prepend($"{GeneratorFacts.SyntaxNamespace}.SyntaxKind kind"));
        var factoryParams = string.Join(", ", propertyInfos.Select(i => $"{i.TypeName} {i.VarName}"));
        var updateParams = string.Join(", ", updateParamList);

        GenerateGreenNode();
        GenerateRedNode();
        GenerateInternalSyntaxFactory();
        GenerateSyntaxFactory();
        GenerateVisitor();
        return;

        void GenerateGreenNode()
        {
            var greenNodeBuilder = new StringBuilder();

            var constructorCodeBuilder = new StringBuilder();
            var writeToCodeBuilder = new StringBuilder();
            var getSlotCodeBuilder = new StringBuilder();

            foreach (var info in propertyInfos)
            {
                constructorCodeBuilder.AppendLine(info.IsNullable
                    ? $$"""
                                if ({{info.VarName}} is not null)
                                {
                                    this.AdjustFullWidth({{info.VarName}});
                                    this.{{info.PropertyName}} = {{info.VarName}};
                                }
                        """
                    : info.IsTokenList || info.IsList
                    ? $$"""
                               if ({{info.VarName}} is not null)
                               {
                                   this.AdjustFullWidth({{info.VarName}});
                                   this.{{info.PropertyName}} = new {{info.TypeName}}({{info.VarName}});
                               }
                       """
                    : $"""
                               this.AdjustFullWidth({info.VarName});
                               this.{info.PropertyName} = {info.VarName};
                       """);

                writeToCodeBuilder.AppendLine(info.IsNullable
                    ? $"        this.{info.PropertyName}.WriteTo(writer);"
                    : info.IsTokenList || info.IsList
                    ? $"        this.{info.PropertyName}.Node?.WriteTo(writer);"
                    : $"        this.{info.PropertyName}.WriteTo(writer);");

                getSlotCodeBuilder.AppendLine(info.IsTokenList || info.IsList
                    ? $"            {info.Slot} => this.{info.PropertyName}.Node,"
                    : $"            {info.Slot} => this.{info.PropertyName},");
            }

            constructorCodeBuilder.Append($$"""
                                                    this.SlotCount = {{propertyInfos.Length}};
                                                }
                                            """);
            writeToCodeBuilder.Append("    }");
            getSlotCodeBuilder.Append("""
                                                  _ => null,
                                              };
                                          }
                                      """);

            greenNodeBuilder.AppendLine($$"""
                                          // <auto-generated/>
                                          #nullable enable

                                          namespace {{GeneratorFacts.SyntaxInternalNamespace}};

                                          partial class {{className}}
                                          {
                                              internal {{className}}({{constructParams}}) : base(kind)
                                              {
                                          {{constructorCodeBuilder}}
                                          
                                              public override GreenNode? GetSlot(int slot)
                                              {
                                                  return slot switch
                                                  {
                                          {{getSlotCodeBuilder}}
                                                  
                                              internal override SyntaxNode CreateRed(SyntaxNode? parent, int position)
                                              {
                                                  return new {{GeneratorFacts.SyntaxNamespace}}.{{className}}(this, parent, position);
                                              }

                                              protected internal override void WriteTo(TextWriter writer)
                                              {
                                                  base.WriteTo(writer);
                                          {{writeToCodeBuilder}}
                                          }
                                          """);

            context.AddSource($"{className}.Internal.g.cs", greenNodeBuilder.ToString());
        }

        void GenerateRedNode()
        {
            var syntaxNodeBuilder = new StringBuilder();

            var fieldCodeBuilder = new StringBuilder();
            var propertyCodeBuilder = new StringBuilder();
            var withCodeBuilder = new StringBuilder();

            for (var i = 0; i < propertyInfos.Length; i++)
            {
                var info = propertyInfos[i];
                var redTypeName = info.TypeName;

                if (info.IsToken)
                {
                    propertyCodeBuilder.AppendLine($"\n    public {info.TypeName} {info.PropertyName} => this.GetToken({info.Slot});");
                }
                else if (info.IsTokenList)
                {
                    redTypeName = "SyntaxTokenList";
                    propertyCodeBuilder.AppendLine($"\n    public SyntaxTokenList {info.PropertyName} => this.GetTokenList({info.Slot});");
                }
                else if (info.IsList)
                {
                    propertyCodeBuilder.AppendLine($"\n    public {info.TypeName} {info.PropertyName} => this.GetList<{((GenericNameSyntax)info.Node.Type).TypeArgumentList.Arguments[0]}>({info.Slot});");
                }
                else
                {
                    var fieldName = $"_{info.VarName}";

                    fieldCodeBuilder.AppendLine(info.IsNullable
                        ? $"\n    private {info.TypeName} {fieldName};"
                        : $"\n    private {info.TypeName}? {fieldName};");

                    propertyCodeBuilder.AppendLine($"\n    public {info.TypeName} {info.PropertyName} => this.GetRed(ref this.{fieldName}, {info.Slot})!;");
                }

                withCodeBuilder.AppendLine($$"""
                                               
                                                   public {{className}} With{{info.PropertyName}}({{redTypeName}} {{info.VarName}})
                                                   {
                                                       return this.Update({{string.Join(", ", updateArgList.SetItem(i, info.VarName))}});
                                                   }
                                               """);
            }

            syntaxNodeBuilder.Append($$"""
                                           // <auto-generated/>
                                           #nullable enable

                                           namespace {{GeneratorFacts.SyntaxNamespace}};

                                           using {{GeneratorFacts.SyntaxFactoryNamespace}};
                                           using {{GeneratorFacts.SyntaxVisitorNamespace}};

                                           public partial class {{className}} : {{inheritClassName}}
                                           {{{fieldCodeBuilder}}
                                           {{propertyCodeBuilder}}
                                               internal {{className}}({{GeneratorFacts.SyntaxInternalNamespace}}.GreenNode node, SyntaxNode? parent, int position) : base(node, parent, position)
                                               {
                                               }
                                               
                                               public override void Accept(ISyntaxVisitor visitor)
                                               {
                                                   visitor.Visit{{factoryName}}(this);
                                               }
                                               
                                               public override TResult Accept<TResult>(ISyntaxVisitor<TResult> visitor)
                                               {
                                                   return visitor.Visit{{factoryName}}(this);
                                               }
                                           
                                               public {{className}} Update({{updateParams}})
                                               {
                                                   return {{GeneratorFacts.SyntaxFactoryName}}.{{factoryName}}({{constructArgs}});
                                               }
                                           {{withCodeBuilder}}}
                                           """);

            context.AddSource($"{className}.g.cs", syntaxNodeBuilder.ToString());
        }

        void GenerateInternalSyntaxFactory()
        {
            var internalSyntaxFactoryBuilder = new StringBuilder();

            internalSyntaxFactoryBuilder.AppendLine($$"""
                                                          // <auto-generated/>
                                                          #nullable enable
                                                          
                                                          namespace {{GeneratorFacts.SyntaxFactoryInternalNamespace}};
                                                          
                                                          using {{GeneratorFacts.SyntaxInternalNamespace}};
                                                          
                                                          using {{className}} = {{GeneratorFacts.SyntaxInternalNamespace}}.{{className}};
                                                          
                                                          internal static partial class {{GeneratorFacts.SyntaxFactoryInternalName}}
                                                          {
                                                              public static {{className}} {{factoryName}}({{factoryParams}})
                                                              {
                                                                  return new {{className}}({{factoryArgs}});
                                                              }
                                                          }
                                                      """);

            context.AddSource($"{GeneratorFacts.SyntaxFactoryInternalName}.{className}.Internal.g.cs", internalSyntaxFactoryBuilder.ToString());
        }

        void GenerateSyntaxFactory()
        {
            var factoryConstructArgs = string.Join(", ", propertyInfos.Select(i =>
            {
                if (i.IsNullable)
                {
                    return $"({GeneratorFacts.SyntaxInternalNamespace}.{i.TypeName}){i.VarName}?.Node";
                }

                if (i.IsTokenList)
                {
                    return $"{i.VarName}.ToGreenList()";
                }

                if (i.IsList)
                {
                    return $"{i.VarName}.Node!.ToGreenList<{((INamedTypeSymbol)i.Symbol!.Type).TypeArguments[0]}>()";
                }

                return $"({GeneratorFacts.SyntaxInternalNamespace}.{i.TypeName}){i.VarName}.Node";
            }));

            var syntaxFactoryBuilder = new StringBuilder();

            syntaxFactoryBuilder.AppendLine($$"""
                                                  // <auto-generated/>
                                                  #nullable enable
                                                  
                                                  namespace {{GeneratorFacts.SyntaxFactoryNamespace}};
                                                  
                                                  using {{GeneratorFacts.SyntaxNamespace}};
                                                  using {{GeneratorFacts.ExtensionsNamespace}};
                                                  using {{className}} = {{GeneratorFacts.SyntaxNamespace}}.{{className}};
                                                  
                                                  public static partial class {{GeneratorFacts.SyntaxFactoryName}}
                                                  {
                                                      public static {{className}} {{factoryName}}({{updateParams}})
                                                      {
                                                          return ({{className}}){{GeneratorFacts.SyntaxFactoryInternalNamespace}}.{{GeneratorFacts.SyntaxFactoryName}}.{{factoryName}}({{factoryConstructArgs}}).CreateRed();
                                                      }
                                                  }
                                              """);

            context.AddSource($"{GeneratorFacts.SyntaxFactoryName}.{className}.g.cs", syntaxFactoryBuilder.ToString());
        }

        void GenerateVisitor()
        {
            var visitorBuilder = new StringBuilder();

            visitorBuilder.AppendLine($$"""
                                      // <auto-generated/>
                                      
                                      namespace {{GeneratorFacts.SyntaxVisitorNamespace}};
                                      
                                      using {{GeneratorFacts.SyntaxNamespace}};
                                      
                                      public partial interface ISyntaxVisitor
                                      {
                                          void Visit{{factoryName}}({{className}} node);
                                      }
                                      
                                      public partial interface ISyntaxVisitor<out TResult>
                                      {
                                          TResult Visit{{factoryName}}({{className}} node);
                                      }
                                      
                                      public abstract partial class SimpleVisitor : ISyntaxVisitor
                                      {
                                          public virtual void Visit{{factoryName}}({{className}} node)
                                          {
                                          }
                                      }
                                      
                                      public abstract partial class SimpleVisitor<TResult> : ISyntaxVisitor<TResult>
                                      {
                                          public virtual TResult Visit{{factoryName}}({{className}} node)
                                          {
                                              return default(TResult);
                                          }
                                      }
                                      """);

            context.AddSource($"{GeneratorFacts.SyntaxVisitorName}.{className}.g.cs", visitorBuilder.ToString());
        }
    }
}