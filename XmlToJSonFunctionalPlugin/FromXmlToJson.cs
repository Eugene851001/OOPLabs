using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using XmlToJSonFunctionalPlugin;

namespace UniverseEditor
{
    class FromXmlToJson: ISerializationProcessing
    {

        public string OnSave(string source, byte additionalOptions)
        {
            string jsonString;
            Token[] tokens = XmlLexer.GetTokens(source);
            tokens = XmlLexer.AddArray(new List<string> { "AstronomicalObject", "UidHash" },
                new List<string>() { "AstroObjects", "AstroObjectsEditors" }, tokens);
            XmlToJsonParser parser = new XmlToJsonParser((SerializationOptions)additionalOptions);
            jsonString = parser.GetJsonString(tokens);
            string removeString = "\"SaveInfo\": ";
            jsonString = jsonString.Substring(removeString.Length, jsonString.Length
                - removeString.Length);
            return jsonString;
        }

        public string OnLoad(string source)
        {
            StringBuilder xmlString = new StringBuilder();
            return xmlString.ToString();
        }
    }
}
