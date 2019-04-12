using System;

namespace TestNinja.Fundamentals
{
    public class HtmlFormatter
    {
        public string FormatAsBold(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException();

            return $"<strong>{content}</strong>";
        }
    }
}