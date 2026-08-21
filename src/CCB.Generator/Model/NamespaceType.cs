namespace CCB.Generator.Model;

using System.Text;

public record NamespaceType(string Name, NamespaceType? Parent = null)
{
    public static NamespaceType Global { get; } = new NamespaceType(string.Empty);

    private static readonly Stack<string> Stack = new Stack<string>();
    private static readonly StringBuilder StringBuilder = new StringBuilder();

    public override string ToString()
    {
        if (this.Parent is null)
        {
            return this.Name + "::";
        }

        for (var current = this.Parent; current is not null; current = current.Parent)
        {
            Stack.Push(current.Name);
        }

        foreach (var part in Stack)
        {
            StringBuilder.Append(part);
            StringBuilder.Append("::");
        }

        var result = StringBuilder.ToString();

        Stack.Clear();
        StringBuilder.Clear();

        return result;
    }
}