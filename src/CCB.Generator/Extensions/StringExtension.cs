namespace CCB.Generator.Extensions;

using System;

public static class StringExtension
{
    extension(string content)
    {
        public string ToCamelCase()
        {
            if (!char.IsUpper(content[0]))
            {
                return content;
            }

            var result = string.Create(
                content.Length,
                content,
                (span, content) =>
                {
                    var contentSpan = content.AsSpan();

                    span[0] = char.ToLowerInvariant(contentSpan[0]);

                    contentSpan[1..].CopyTo(span[1..]);
                });

            return result;
        }

        public string ToUpperCamelCase()
        {
            var index = content[0] == '@' ? 1 : 0;

            if (char.IsUpper(content[index]))
            {
                return content;
            }

            var result = string.Create(
                content.Length,
                content,
                (span, content) =>
                {
                    var contentSpan = content.AsSpan();

                    contentSpan.CopyTo(span);
                    span[index] = char.ToUpperInvariant(contentSpan[index]);
                });

            return result;
        }
    }
}