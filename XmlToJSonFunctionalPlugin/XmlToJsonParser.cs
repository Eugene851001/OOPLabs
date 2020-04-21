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
        string openArrayBrackets = ": [";
        string closeArrayBrackets = "]";
        string nextLine = "";
        string delimeter = ",";
        string currentTab = "";
        string tab = "";

        public XmlToJsonParser()
        {
            additionalOptions = SerializationOptions.None;
        }
        public XmlToJsonParser(SerializationOptions serializationOptions)
        {
            this.additionalOptions = serializationOptions;
            if((serializationOptions & SerializationOptions.WriteIndent) != 0)
            {
                tab = "  ";
                nextLine = "\r\n";
                openComplexBrackets = ": {\r\n";
                openArrayBrackets = ": [\r\n";
                delimeter = ", \r\n";
            }
        }

        bool isNumeric(string str)
        {
            bool result = true;
            try
            {
                int i = int.Parse(str);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        bool addValue(int index)
        {
            string value = tokens[index].Value;
            if (isNumeric(value) || value.Equals("true") || value.Equals("false"))
            {
                jsonString += value;
            }
            else
            {
                jsonString += "\"" + value + "\"";
            }
            return true;
        }

        bool addOpenBrackets()
        {
            currentTab += tab;
            jsonString += openComplexBrackets + currentTab;
            return true;
        }

        bool addCloseBracket()
        {
            if (currentTab.Length > 0 || tab.Length == 0)
            {
                jsonString += nextLine + (currentTab = currentTab.
                    Substring(0, currentTab.Length - tab.Length)) + closeComplexBrackets;
            }
            return true;
        }

        bool addOpenArrayElement()
        {
            currentTab += tab;
            jsonString += "{" + nextLine + currentTab;
            return true;
        }

        bool addCloseArrayElement()
        {
            if(currentTab.Length > 0 || tab.Length == 0)
            {
                jsonString += nextLine + (currentTab = currentTab.
                    Substring(0, currentTab.Length - tab.Length)) + "}";
            }
            return true;
        }

        bool addOpenArray()
        {
            jsonString += openArrayBrackets + (currentTab += tab);

            return true;
        }

        bool addCloseArray()
        {
            if (currentTab.Length > 0 || tab.Length == 0)
            {
                jsonString += nextLine + (currentTab = currentTab.
                    Substring(0, currentTab.Length - tab.Length)) + closeArrayBrackets;
            }
            return true;
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
                && addValue(SaveNext);
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
                addOpenBrackets() && OptionalWhiteSpace() && Expression() 
                && OptionalWhiteSpace()&& CloseBracket() && addCloseBracket() && OptionalExpression() ;
        }

        bool OptionalArrayElementsSequence()
        {
            int saveNext = Next;
            char[] saveBufferJson = new char[jsonString.Length];
            jsonString.CopyTo(0, saveBufferJson, 0, jsonString.Length);
            string saveString = new string(saveBufferJson);
            jsonString += delimeter;
            jsonString += currentTab;
            return ArrayElement() ||(Next = saveNext) != -1 && (jsonString = saveString) != null;
        }

        bool ArrayElement()
        {
            return Term(new Token() { Type = TokenType.OpenArrayElement }) && addOpenArrayElement()
                && OptionalWhiteSpace() && Expression() && OptionalWhiteSpace() &&
                Term(new Token() { Type = TokenType.CloseArrayElement }) && addCloseArrayElement()
                && OptionalWhiteSpace();
        }

        bool Array()
        {
            return OptionalVersion() && OptionalWhiteSpace() && OpenBracket() && OptionalWhiteSpace()
                && Term(new Token() { Type = TokenType.OpenArray }) && addOpenArray() 
                && OptionalWhiteSpace() && ArrayElement() && OptionalWhiteSpace() && 
                OptionalArrayElementsSequence() && Term(new Token { Type = TokenType.CloseArray }) 
                && addCloseArray() && OptionalWhiteSpace() && CloseBracket() && OptionalExpression();
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
               saveString) != null && (currentTab = saveTab) != null && SimpleExpression() 
               || (Next = SaveNext) != -1 && (jsonString = saveString) != null 
               && (currentTab = saveTab) != null && Array();
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
