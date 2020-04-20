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
            XmlToJsonParser parser = new XmlToJsonParser((SerializationOptions)additionalOptions);
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
