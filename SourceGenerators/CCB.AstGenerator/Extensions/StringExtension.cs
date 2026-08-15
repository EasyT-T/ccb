namespace CCB.AstGenerator.Extensions;

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

            return char.ToLowerInvariant(content[0]) + content.Substring(1);
        }
    }
}