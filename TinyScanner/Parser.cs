using System.Windows.Forms;
using System;

using System.Collections.Generic;

namespace TinyScanner
{
    public class Parser
    {
        private List<Token> tokens;
        private int current = 0;

        public Parser(List<Token> tokens)
        {
            this.tokens = tokens;
        }

        private Token Current()
        {
            if (current < tokens.Count)
                return tokens[current];

            return null;
        }

        private void Advance()
        {
            current++;
        }

        private void Match(TokenType type)
        {
            if (Current() != null && Current().Type == type)
            {
                Advance();
            }
            else
            {
                string actual = Current()?.Lexeme ?? "EOF";
                throw new Exception($"Syntax Error: expected {type}, but found '{actual}'");
            }
        }

        public void Parse()
        {
            Statements();

            if (current == tokens.Count)
                MessageBox.Show("Parsing Successful");
            else
                MessageBox.Show("Syntax Error");
        }

        private void Statements()
        {
            Statement();

            while (Current() != null &&
                  (Current().Type == TokenType.Semicolon ||
                   Current().Type == TokenType.Identifier ||
                   Current().Lexeme == "repeat"))
            {
                if (Current().Type == TokenType.Semicolon)
                {
                    Advance();
                }
                else
                {
                    Statement();
                }
            }
        }

        private void Statement()
        {
            if (Current() == null)
                throw new Exception("Syntax Error: unexpected end of input");

            if (Current().Type == TokenType.Identifier)
                Assignment();

            else if (Current().Lexeme == "repeat")
                Repeat();

            else
                throw new Exception($"Syntax Error: invalid statement starting with '{Current().Lexeme}'");
        }

        private void Assignment()
        {
            Match(TokenType.Identifier);
            Match(TokenType.Assign);
            Expression();
        }

        private void Repeat()
        {
            Match(TokenType.Keyword); 

            Statements(); 

            if (Current() != null && Current().Lexeme == "until")
            {
                Advance(); 
            }
            else
            {
                throw new Exception("Expected 'until'");
            }

            Condition();
        }
        private void Condition()
        {
            Expression();

            if (Current().Type == TokenType.LessThan ||
                Current().Type == TokenType.GreaterThan ||
                Current().Type == TokenType.Equal ||
                Current().Type == TokenType.NotEqual)
            {
                Advance();
            }
            else
                throw new Exception("Expected Comparison Operator");

            Expression();
        }

        private void Expression()
        {
            Term();

            while (Current() != null &&
                  (Current().Type == TokenType.Plus ||
                   Current().Type == TokenType.Minus))
            {
                Advance();
                Term();
            }
        }

        private void Term()
        {
            Factor();

            while (Current() != null &&
                  (Current().Type == TokenType.Multiply ||
                   Current().Type == TokenType.Divide))
            {
                Advance();
                Factor();
            }
        }

        private void Factor()
        {
            if (Current().Type == TokenType.Number)
                Match(TokenType.Number);

            else if (Current().Type == TokenType.Identifier)
                Match(TokenType.Identifier);

            else if (Current().Type == TokenType.LeftParen)
            {
                Match(TokenType.LeftParen);
                Expression();
                Match(TokenType.RightParen);
            }
            else
                throw new Exception("Invalid Expression");
        }
    }
}