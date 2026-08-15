namespace CCB.Parser;

using CCB.Syntax.Factory.Internal;
using CCB.Syntax.Internal;
using SyntaxToken = CCB.Syntax.Internal.SyntaxToken;
using SyntaxKind = CCB.Syntax.SyntaxKind;

internal partial class SyntaxParser(TokenWindow tokenWindow)
{
    private TokenWindow _tokenWindow = tokenWindow;

    public RootSyntax ParseToEnd()
    {
        var members = new List<GreenNode>();

        SyntaxToken token;

        while ((token = this._tokenWindow.PeekToken()).Kind != SyntaxKind.EndOfFile)
        {
            switch (token.Kind)
            {
                case SyntaxKind.Class:
                    members.Add(this.ParseClass());
                    break;
                default:
                    members.Add(this.ParseGlobalSyntax());
                    break;
            }
        }

        return SyntaxFactory.Root(SyntaxFactory.List(members), token);
    }
}