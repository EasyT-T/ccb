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
    }
}