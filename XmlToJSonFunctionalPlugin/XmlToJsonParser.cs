using System;
using System.Collections.Generic;
using System.Text;
using UniverseEditor;

namespace XmlToJSonFunctionalPlugin
{
    class XmlToJsonParser
    {

        Token[] tokens;

        int Next;
        string jsonString;

        SerializationOptions additionalOptions;

        string openComplexBrackets = ":{";
        string closeComplexBrackets = "}";
        string nextLine = "";
        string delimeter = ",";
        string currentTab = "";
        string tab = "  ";

        public XmlToJsonParser()
        {
            additionalOptions = SerializationOptions.None;
        }
        public XmlToJsonParser(SerializationOptions serializationOptions)
        {
            this.additionalOptions = serializationOptions;
            if((serializationOptions & SerializationOptions.WriteIndent) != 0)
            {
                nextLine = "\r\n";
                openComplexBrackets = ": {\r\n";
                delimeter = ", \r\n";
            }
        }

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
            int SaveNext = Next;
            return Term(new Token() { Type = TokenType.OpenBracket })
                && (jsonString += "\"" + tokens[SaveNext].Value + "\"") != null;
        }

        bool CloseBracket()
        {
            return Term(new Token() { Type = TokenType.CloseBracket});
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
            //предполагается, что SaveNext никогда не равно -1
            return BasicValue(); //|| (Next = SaveNext) != -1 && Expression();
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
            char[] saveBuffer = new char[jsonString.Length];
            jsonString.CopyTo(0, saveBuffer, 0, jsonString.Length);
            string saveString = new string(saveBuffer);
            char[] saveBufferTab = new char[currentTab.Length];
            currentTab.CopyTo(0, saveBufferTab, 0, saveBufferTab.Length);
            string saveTab = new string(saveBufferTab);
            jsonString += delimeter;
            jsonString += currentTab;
            return (Next < tokens.Length) && Expression() || (jsonString = saveString) != null 
                && (currentTab = saveTab) != null && (Next = SaveNext) != -1;
        }

        bool SimpleExpression()
        {
            int SaveNext = Next;
            return OptionalVersion() && OptionalWhiteSpace() && OpenBracket() && (jsonString += ": ") != null 
                && OptionalWhiteSpace() && Value() && OptionalWhiteSpace() && CloseBracket() && 
                OptionalWhiteSpace() && OptionalExpression(); 
        }

        bool ComplexExpression()
        {
            return OptionalVersion() && OptionalWhiteSpace() && OpenBracket() && 
                (jsonString += openComplexBrackets + (currentTab += tab)) != null && OptionalWhiteSpace() && Expression() 
                && OptionalWhiteSpace()&& CloseBracket() && (jsonString += nextLine + (currentTab = currentTab.
                Substring(0, currentTab.Length - tab.Length)) + closeComplexBrackets) != null && OptionalExpression() ;
        }
         
        bool Expression()
        {
            int SaveNext = Next;
            char[] saveBufferJson = new char[jsonString.Length];
            jsonString.CopyTo(0, saveBufferJson, 0, jsonString.Length);
            string saveString = new string(saveBufferJson);
            char[] saveBufferTab = new char[currentTab.Length];
            currentTab.CopyTo(0, saveBufferTab, 0, saveBufferTab.Length);
            string saveTab = new string(saveBufferTab);
            return ComplexExpression() || (Next = SaveNext) != -1 && (jsonString = 
               saveString) != null && (currentTab = saveTab) != null && SimpleExpression();
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
