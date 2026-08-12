namespace CCB.IO;

using System.Text;

public readonly struct TextWindow(Stream stream) : IDisposable
{
    private readonly StringBuilder _builder = new StringBuilder();
    private readonly StreamReader _reader = new StreamReader(stream);

    public int Position => this._builder.Length;

    public char PeekChar()
    {
        var value = this._reader.Peek();
        var c = value == -1 ? '\0' : (char)value;

        return c;
    }

    public char AdvanceChar()
    {
        var value = this._reader.Read();
        var c = value == -1 ? '\0' : (char)value;

        this._builder.Append(c);

        return c;
    }

    public void Advance(int offset)
    {
        Span<char> span = stackalloc char[offset];

        this._reader.Read(span);

        this._builder.Append(span);
    }

    public string GetString(int start, int length)
    {
        return this._builder.ToString(start, length);
    }

    public void Dispose()
    {
        stream.Dispose();

        this._builder.Clear();
    }
}