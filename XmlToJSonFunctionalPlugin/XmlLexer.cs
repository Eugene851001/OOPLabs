using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace XmlToJSonFunctionalPlugin
{

    public enum TokenType {Uknown, OpenBracket, CloseBracket, Value, Version, WhiteSpace};
    public struct Token
    {
        public TokenType Type;
        public string Value;

        public override bool Equals(object obj)
        {
            return Type == ((Token)obj).Type && Value.Equals(((Token)obj).Value);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    class XmlLexer
    {
        public static Token[] GetTokens(string source)
        {
            List<Token> tokens = new List<Token>();
            Regex pattern = new Regex("(<\\w+[^>]*>)|(</\\w+>)|(<\\?.*>)|(\\s+)|([a-zA-Z0-9]+)");
            MatchCollection matches = pattern.Matches(source);
            foreach(Match match in matches)
            {
                Token token = new Token();
                if (match.Value.Equals(match.Groups[1].Value))
                {
                    token.Type = TokenType.OpenBracket;
                    Regex value = new Regex("\\w+");
                    token.Value = value.Match(match.Groups[1].Value).Value;
                } else if(match.Value.Equals(match.Groups[2].Value))
                {
                    token.Type = TokenType.CloseBracket;
                    Regex value = new Regex("\\w+");
                    token.Value = value.Match(match.Groups[2].Value).Value;
                }
                else if(match.Value.Equals(match.Groups[3].Value))
                {
                    token.Type = TokenType.Version;
                }
                else if (match.Value.Equals(match.Groups[4].Value))
                {
                    token.Type = TokenType.WhiteSpace;
                }
                else if(match.Value.Equals(match.Groups[5].Value))
                {
                    token.Type = TokenType.Value;
                    token.Value = match.Groups[5].Value;
                }
                tokens.Add(token);
            }
            return tokens.ToArray();
        }
    }
}
