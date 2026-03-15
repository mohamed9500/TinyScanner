using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyScanner
{
    public class Token
    {
        public string Lexeme { get; set; }
        public TokenType Type { get; set; }

        public Token(string lexeme, TokenType type)
        {
            Lexeme = lexeme;
            Type = type;
        }

        public override string ToString()
        {
            return $"{Lexeme} -> {Type}";
        }
    }
}
