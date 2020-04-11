using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using XmlToJSonFunctionalPlugin;

namespace UniverseEditor
{
    class FromXmlToJson: ISerializationProcessing
    {

        List<string> typesNames = new List<string>();
        
        void HelpConvertToJSon(string source, StringBuilder jsonString, int typeCounter)
        {
     //       Regex pattern = new Regex("<" + typesNames[typeCounter] + "(\\sxsi:type=\"\\w+\")?>(.*)</" 
       //         + typesNames[typeCounter]+">");

            Regex pattern = new Regex("<" + typesNames[typeCounter] + "(.*)</"
                + typesNames[typeCounter] + ">");

            MatchCollection matches = pattern.Matches(source);
            if (matches.Count > 1)
            {
                foreach (Match match in matches)
                {
                    jsonString.Append("\"" + typesNames[typeCounter] + "\": {");
                    HelpConvertToJSon(match.Groups[2].Value, jsonString, typeCounter + 1);
                    jsonString.Append("}, ");
                }
            }
            else
            {
                if (matches.Count == 1)
                    jsonString.Append("\"" + typesNames[typeCounter] + "\": " + matches[0].Groups[2].Value);
            }
        }

        public string OnSave(string source)
        {
            string jsonString;
            Token[] tokens = XmlLexer.GetTokens(source);
            XmlToJsonParser parser = new XmlToJsonParser();
            jsonString = parser.GetJsonString(tokens);
            return jsonString;
        }

        public string OnLoad(string source)
        {
            StringBuilder xmlString = new StringBuilder();
            return xmlString.ToString();
        }
    }
}
