namespace CCB.Syntax;

using CCB.Syntax.Factory;
using CCB.Syntax.Internal;
using CCB.Syntax.Visitor;

public class RootSyntax : SyntaxNode
{
    internal RootSyntax(GreenNode node, SyntaxNode? parent, int position) : base(node, parent, position)
    {
    }

    public SyntaxList<SyntaxNode> Members => this.GetList<SyntaxNode>(0);

    public SyntaxToken EndOfFile => this.GetToken(1);

    public RootSyntax Update(SyntaxList<SyntaxNode> members, SyntaxToken endOfFile)
    {
        return SyntaxFactory.Root(members, endOfFile);
    }

    public RootSyntax WithMembers(SyntaxList<SyntaxNode> members)
    {
        return this.Update(members, this.EndOfFile);
    }

    public RootSyntax WithEndOfFile(SyntaxToken endOfFile)
    {
        return this.Update(this.Members, endOfFile);
    }

    public override void Accept(ISyntaxVisitor visitor)
    {
        visitor.VisitRoot(this);
    }

    public override TResult Accept<TResult>(ISyntaxVisitor<TResult> visitor)
    {
        return visitor.VisitRoot(this);
    }
}