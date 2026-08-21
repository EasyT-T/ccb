namespace CCB.Lexer;

using System.Text;

internal partial class SyntaxLexer
{
    private string LexSlash()
    {
        var commentBuilder = new StringBuilder();

        commentBuilder.Append(textWindow.AdvanceChar());

        var c = textWindow.AdvanceChar();

        switch (c)
        {
            case '/':
            {
                commentBuilder.Append(c);

                while ((c = textWindow.PeekChar()) != '\n' && c != '\r' && c != '\0')
                {
                    commentBuilder.Append(textWindow.AdvanceChar());
                }
                break;
            }
            case '*':
            {
                commentBuilder.Append(c);

                while (true)
                {
                    c = textWindow.AdvanceChar();

                    if (c == '\0')
                    {
                        break;
                    }

                    commentBuilder.Append(c);

                    if (c != '*')
                    {
                        continue;
                    }

                    if (textWindow.PeekChar() != '/')
                    {
                        continue;
                    }

                    commentBuilder.Append(textWindow.AdvanceChar());
                    break;
                }

                break;
            }
            default:
                throw new InvalidOperationException();
        }

        return commentBuilder.ToString();
    }
}