namespace CCB.Syntax.Visitor;

using System.Diagnostics;

public abstract partial class SimpleVisitor
{
    public virtual void VisitRoot(RootSyntax root)
    {
    }
}

public abstract partial class SimpleVisitor<TResult>
{
    public virtual TResult VisitRoot(RootSyntax root)
    {
        throw new UnreachableException();
    }
}