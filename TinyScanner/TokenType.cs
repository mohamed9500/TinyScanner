using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyScanner
{
    public enum TokenType
    {
        Number,
        String,
        Identifier,
        Keyword,
        Comment,

        Plus,
        Minus,
        Multiply,
        Divide,

        Assign,
        LessThan,
        GreaterThan,
        Equal,
        NotEqual,

        And,
        Or,

        Semicolon,
        Comma,

        LeftParen,
        RightParen,

        LeftBrace,
        RightBrace
    }
}
