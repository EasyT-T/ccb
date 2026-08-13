namespace CCB.Generator;

using System.Text;

internal class IndentedTextWriter(TextWriter innerWriter, string indentString = "    ") : TextWriter
{
    private int _indentLevel;
    private bool _isAtFirstLine = true;

    public override Encoding Encoding { get; } = innerWriter.Encoding;

    public IndentScope Indent()
    {
        this._indentLevel++;
        return new IndentScope(this);
    }

    public override void Write(char value)
    {
        if (this._isAtFirstLine && value is not '\r' and not '\n')
        {
            this.WriteIndent();
            this._isAtFirstLine = false;
        }

        innerWriter.Write(value);

        if (value is '\n')
        {
            this._isAtFirstLine = true;
        }
    }

    private void WriteIndent()
    {
        for (var i = 0; i < this._indentLevel; i++)
        {
            innerWriter.Write(indentString);
        }
    }

    public readonly ref struct IndentScope(IndentedTextWriter writer)
    {
        public void Dispose()
        {
            writer._indentLevel--;
        }
    }
}