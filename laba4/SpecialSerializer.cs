using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UniverseEditor
{
    class SpecialSerializer: ISerialize
    {
        ISerializationProcessing processSerialization;
        public byte AdditionalSettings;

        public SpecialSerializer(ISerializationProcessing processSerialization, byte additionalSettings)
        {
            AdditionalSettings = additionalSettings;
            this.processSerialization = processSerialization;
        }
        public void Serialize(object obj, string path, Type[] types)
        {
            FileStream fout = new FileStream(path, FileMode.Create);
            try
            {
                StringWriter writer = new StringWriter();
                XmlSerializer formatter = new XmlSerializer(typeof(SaveInfo), types);
                formatter.Serialize(writer, obj);
                string processedString = processSerialization.OnSave(writer.ToString(), AdditionalSettings);
                fout.Write(Encoding.ASCII.GetBytes(processedString), 0, 
                    Encoding.ASCII.GetBytes(processedString).Length);
                writer.Close();
            }
            finally
            {
                fout.Close();
            }
        }

        public object Deserialize(string path, Type[] types)
        {
            FileStream fin = new FileStream(path, FileMode.Open);
            SaveInfo info;
            try
            {
                byte[] buffer = new byte[fin.Length];
                fin.Read(buffer, 0, (int)fin.Length);
                string source = Encoding.ASCII.GetString(buffer);
                string result = processSerialization.OnLoad(source);
                MemoryStream container = new MemoryStream(Encoding.ASCII.GetBytes(result));
                var jsonSerializer = new DataContractJsonSerializer(typeof(SaveInfo), types);
                info = (SaveInfo)jsonSerializer.ReadObject(container);
            }
            finally
            {
                fin.Close();
            }
            return info;
        }
    }
}
