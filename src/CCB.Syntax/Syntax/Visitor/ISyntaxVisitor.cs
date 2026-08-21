namespace CCB.Syntax.Visitor;

public partial interface ISyntaxVisitor
{
    void VisitRoot(RootSyntax root);
}

public partial interface ISyntaxVisitor<out TResult>
{
    TResult VisitRoot(RootSyntax root);
}