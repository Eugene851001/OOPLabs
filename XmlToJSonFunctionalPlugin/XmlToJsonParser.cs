using System;
using System.Collections.Generic;
using System.Text;

namespace XmlToJSonFunctionalPlugin
{
    class XmlToJsonParser
    {

        Token[] tokens;

        int Next;
        string jsonString;

        bool Term(Token expected)
        {
            if (Next < tokens.Length)
                return tokens[Next++].Type == expected.Type;
            else
                return false;
        }
        bool StrictTerm(Token expected)
        {
            return tokens[Next++].Equals(expected);
        }

        bool OpenBracket()
        {
            jsonString += "{";
            int SaveNext = Next;
            return Term(new Token() { Type = TokenType.OpenBracket })
                && (jsonString += "\"" + tokens[SaveNext].Value + "\"") != null;
        }

        bool CloseBrackets()
        {
            return Term(new Token() { Type = TokenType.CloseBracket}) 
                && (jsonString += "}") != null;
        }

        bool BasicValue()
        {
            int SaveNext = Next;
            return Term(new Token() { Type = TokenType.Value })
                && (jsonString += tokens[SaveNext].Value) != null;
        }

        bool Value()
        {
            int SaveNext = Next;
            jsonString += ": ";
            //предполагается, что SaveNext никогда не равно -1
            return BasicValue() || (Next = SaveNext) != -1 && Expression();
        }

        bool OptionalWhiteSpace()
        {
            int SaveNext = Next;
            return Term(new Token() { Type = TokenType.WhiteSpace }) || (Next = SaveNext) != -1;
        }

        bool OptionalVersion()
        {
            int SaveNext = Next;
            return Term(new Token() { Type = TokenType.Version } ) || (Next = SaveNext) != -1;
        }

        bool OptionalExpression()
        {
            int SaveNext = Next;
            return (Next < tokens.Length) && Expression() || (Next = SaveNext) != -1;
        }

        bool Expression()
        {
            int SaveNext = Next;
            return OptionalVersion() && OptionalWhiteSpace() && OpenBracket() && OptionalWhiteSpace()
                && Value() && OptionalWhiteSpace() && CloseBrackets() && OptionalWhiteSpace() && OptionalExpression(); 
        }

        public string GetJsonString(Token[] tokens)
        {
            this.tokens = tokens;
            jsonString = "";
            Expression();
            return jsonString;
        }
    }
}
