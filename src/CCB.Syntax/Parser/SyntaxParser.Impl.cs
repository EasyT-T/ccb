namespace CCB.Parser;

using CCB.Syntax.Factory.Internal;
using CCB.Syntax.Internal;
using ClassDeclarationSyntax = CCB.Syntax.Internal.ClassDeclarationSyntax;
using SyntaxFacts = CCB.Syntax.SyntaxFacts;
using SyntaxToken = CCB.Syntax.Internal.SyntaxToken;
using SyntaxKind = CCB.Syntax.SyntaxKind;

internal partial class SyntaxParser
{
    private ClassDeclarationSyntax ParseClass()
    {
        var classKeyword = this._tokenWindow.AdvanceToken();

        var identifier = this._tokenWindow.AdvanceToken();

        var openBrace = this._tokenWindow.AdvanceToken();

        var members = new List<MemberDeclarationSyntax>();

        SyntaxToken token;

        while ((token = this._tokenWindow.PeekToken()).Kind != SyntaxKind.CloseBrace)
        {
            members.Add(this.ParseMember());
        }

        var closeBrace = token;

        this._tokenWindow.AdvanceToken();

        return SyntaxFactory.ClassDeclaration(classKeyword, identifier, openBrace, new SyntaxList<MemberDeclarationSyntax>(SyntaxFactory.List(members)), closeBrace);
    }

    private MemberDeclarationSyntax ParseMember()
    {
        var leadingModifiers = new List<SyntaxToken>();

        while (true)
        {
            var token = this._tokenWindow.PeekToken();

            if (SyntaxFacts.IsAccessModifier(token.Kind) || token.Kind is SyntaxKind.Const)
            {
                leadingModifiers.Add(token);

                this._tokenWindow.AdvanceToken();
            }
            else
            {
                break;
            }
        }

        var type = this.ParseTypeSyntax();

        var identifier = this._tokenWindow.AdvanceToken();

        if (this._tokenWindow.PeekToken().Kind == SyntaxKind.OpenParen)
        {
            var paramList = this.ParseParameterList();

            var trailingModifiers = new List<SyntaxToken>();

            while (true)
            {
                var token = this._tokenWindow.PeekToken();

                if (SyntaxFacts.IsAccessModifier(token.Kind) || token.Kind is SyntaxKind.Const)
                {
                    trailingModifiers.Add(token);

                    this._tokenWindow.AdvanceToken();
                }
                else
                {
                    break;
                }
            }

            var semicolon = this._tokenWindow.AdvanceToken(); // TODO

            return SyntaxFactory.MethodDeclaration(
                new SyntaxList<SyntaxToken>(SyntaxFactory.List(leadingModifiers)),
                type,
                identifier,
                paramList,
                new SyntaxList<SyntaxToken>(SyntaxFactory.List(trailingModifiers)),
                semicolon);
        }
        else
        {
            var semicolon = this._tokenWindow.AdvanceToken();

            return SyntaxFactory.FieldDeclaration(new SyntaxList<SyntaxToken>(SyntaxFactory.List(leadingModifiers)), type, identifier, semicolon);
        }
    }

    private ParameterListSyntax ParseParameterList()
    {
        var openParen = this._tokenWindow.AdvanceToken();

        var paramList = new List<ParameterSeparatedElementSyntax>();
        SyntaxToken token;

        while ((token = this._tokenWindow.PeekToken()).Kind is not SyntaxKind.CloseParen)
        {
            var param = this.ParseParameter();

            token = this._tokenWindow.PeekToken();

            SyntaxToken separator;

            if (token.Kind == SyntaxKind.Comma)
            {
                separator = token;
                this._tokenWindow.AdvanceToken();
            }
            else
            {
                separator = SyntaxToken.None;
            }

            paramList.Add(SyntaxFactory.ParameterSeparatedElement(param, separator));
        }

        var closeParen = token;
        this._tokenWindow.AdvanceToken();

        return SyntaxFactory.ParameterList(
            openParen,
            new SyntaxList<ParameterSeparatedElementSyntax>(SyntaxFactory.List(paramList)),
            closeParen);
    }

    private ParameterSyntax ParseParameter()
    {
        var paramType = this.ParseTypeSyntax();
        var token = this._tokenWindow.PeekToken();
        SyntaxToken identifier;

        if (token.Kind == SyntaxKind.Identifier)
        {
            identifier = token;
            this._tokenWindow.AdvanceToken();
        }
        else
        {
            identifier = SyntaxToken.None;
        }

        SyntaxToken equalTo;
        SyntaxToken defaultValue;

        if ((token = this._tokenWindow.PeekToken()).Kind == SyntaxKind.EqualTo)
        {
            equalTo = token;
            this._tokenWindow.AdvanceToken();

            defaultValue = this._tokenWindow.AdvanceToken();
        }
        else
        {
            equalTo = SyntaxToken.None;
            defaultValue = SyntaxToken.None;
        }

        return SyntaxFactory.Parameter(paramType, identifier, equalTo, defaultValue);
    }

    private TypeSyntax ParseTypeSyntax()
    {
        var typeToken = this._tokenWindow.AdvanceToken();

        var token = this._tokenWindow.PeekToken();

        SyntaxToken refHandle;
        SyntaxToken inout;

        switch (token.Kind)
        {
            case SyntaxKind.Handle:
                refHandle = token;
                inout = SyntaxToken.None;

                this._tokenWindow.AdvanceToken();

                break;
            case SyntaxKind.Ampersand:
                refHandle = token;

                this._tokenWindow.AdvanceToken();

                if ((token = this._tokenWindow.PeekToken()).Kind is SyntaxKind.In or SyntaxKind.Out)
                {
                    inout = token;

                    this._tokenWindow.AdvanceToken();
                }
                else
                {
                    inout = SyntaxToken.None;
                }
                break;
            default:
                refHandle = SyntaxToken.None;
                inout = SyntaxToken.None;
                break;
        }

        return SyntaxFactory.Type(typeToken, refHandle, inout);
    }

    private GreenNode ParseGlobalSyntax()
    {
        var leadingModifiers = new List<SyntaxToken>();

        SyntaxToken token;

        while (true)
        {
            token = this._tokenWindow.PeekToken();

            if (SyntaxFacts.IsAccessModifier(token.Kind) || token.Kind is SyntaxKind.Const)
            {
                leadingModifiers.Add(token);

                this._tokenWindow.AdvanceToken();
            }
            else
            {
                break;
            }
        }

        var leadingModifiersList = new SyntaxList<SyntaxToken>(SyntaxFactory.List(leadingModifiers));
        var type = this.ParseTypeSyntax();
        var identifier = this._tokenWindow.AdvanceToken();

        token = this._tokenWindow.PeekToken();

        return token.Kind == SyntaxKind.OpenParen
            ? this.ParseFunction(leadingModifiersList, type, identifier)
            : this.ParseGlobalProperty(leadingModifiersList, type, identifier);
    }

    private GlobalPropertySyntax ParseGlobalProperty(SyntaxList<SyntaxToken> leadingModifiers, TypeSyntax type, SyntaxToken identifier)
    {
        var semicolon = this._tokenWindow.AdvanceToken();

        return SyntaxFactory.GlobalProperty(leadingModifiers, type, identifier, semicolon);
    }

    private FunctionDeclarationSyntax ParseFunction(SyntaxList<SyntaxToken> leadingModifiers, TypeSyntax type, SyntaxToken identifier)
    {
        var paramList = this.ParseParameterList();

        var semicolon = this._tokenWindow.AdvanceToken(); // TODO

        return SyntaxFactory.FunctionDeclaration(
            leadingModifiers,
            type,
            identifier,
            paramList,
            semicolon);
    }
}