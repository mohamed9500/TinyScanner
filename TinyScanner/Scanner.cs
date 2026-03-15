using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TinyScanner;



//كل كائن Token يمثل توكن واحد مع نوعه.

//الخطوة 3️⃣: Scanner.cs

//أضف هذا الملف:

//using System.Text.RegularExpressions;

namespace TinyScanner
{
    public class Scanner
    {
        private static readonly Dictionary<string, TokenType> Keywords = new()
        {
            {"int",TokenType.Keyword},
            {"float",TokenType.Keyword},
            {"string",TokenType.Keyword},
            {"read",TokenType.Keyword},
            {"write",TokenType.Keyword},
            {"repeat",TokenType.Keyword},
            {"until",TokenType.Keyword},
            {"if",TokenType.Keyword},
            {"elseif",TokenType.Keyword},
            {"else",TokenType.Keyword},
            {"then",TokenType.Keyword},
            {"return",TokenType.Keyword},
            {"endl",TokenType.Keyword}
        };

        public List<Token> Scan(string code)
        {
            List<Token> tokens = new();

            string pattern =
                @"(/\*.*?\*/)|""[^""]*""|\d+(\.\d+)?|:=|<>|&&|\|\||[+\-*/=<>(){},;]|[a-zA-Z][a-zA-Z0-9]*";

            var matches = Regex.Matches(code, pattern);

            foreach (Match m in matches)
            {
                string value = m.Value;

                if (Regex.IsMatch(value, @"^\d+(\.\d+)?$"))
                    tokens.Add(new Token(value, TokenType.Number));
                else if (Regex.IsMatch(value, "^\".*\"$"))
                    tokens.Add(new Token(value, TokenType.String));
                else if (Keywords.ContainsKey(value))
                    tokens.Add(new Token(value, TokenType.Keyword));
                else if (Regex.IsMatch(value, @"^[a-zA-Z][a-zA-Z0-9]*$"))
                    tokens.Add(new Token(value, TokenType.Identifier));
                else if (value == "+")
                    tokens.Add(new Token(value, TokenType.Plus));
                else if (value == "-")
                    tokens.Add(new Token(value, TokenType.Minus));
                else if (value == "*")
                    tokens.Add(new Token(value, TokenType.Multiply));
                else if (value == "/")
                    tokens.Add(new Token(value, TokenType.Divide));
                else if (value == ":=")
                    tokens.Add(new Token(value, TokenType.Assign));
                else if (value == "<")
                    tokens.Add(new Token(value, TokenType.LessThan));
                else if (value == ">")
                    tokens.Add(new Token(value, TokenType.GreaterThan));
                else if (value == "=")
                    tokens.Add(new Token(value, TokenType.Equal));
                else if (value == "<>")
                    tokens.Add(new Token(value, TokenType.NotEqual));
                else if (value == "&&")
                    tokens.Add(new Token(value, TokenType.And));
                else if (value == "||")
                    tokens.Add(new Token(value, TokenType.Or));
                else if (value == ";")
                    tokens.Add(new Token(value, TokenType.Semicolon));
                else if (value == ",")
                    tokens.Add(new Token(value, TokenType.Comma));
                else if (value == "(")
                    tokens.Add(new Token(value, TokenType.LeftParen));
                else if (value == ")")
                    tokens.Add(new Token(value, TokenType.RightParen));
                else if (value == "{")
                    tokens.Add(new Token(value, TokenType.LeftBrace));
                else if (value == "}")
                    tokens.Add(new Token(value, TokenType.RightBrace));
                else if (Regex.IsMatch(value, @"^/\*.*\*/$"))
                    tokens.Add(new Token(value, TokenType.Comment));
            }

            return tokens;
        }
    }
}
