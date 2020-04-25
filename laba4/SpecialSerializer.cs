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
        public ISerializationProcessing processSerialization;
        public byte AdditionalSettings;
        public IStringSerialize Serializer;
        public IStringSerialize Deserializer;


        public SpecialSerializer()
        {
            Serializer = new SerializerXml();
            Deserializer = new SerializerXml();
            AdditionalSettings = 0;
            this.processSerialization = null;
        }
        public SpecialSerializer(ISerializationProcessing processSerialization, byte additionalSettings)
        {
            Serializer = new SerializerXml();
            Deserializer = new SerializerXml();
            AdditionalSettings = additionalSettings;
            this.processSerialization = processSerialization;
        }
        public void Serialize(object obj, string path, Type[] types)
        {
            FileStream fout = new FileStream(path, FileMode.Create);
            try
            {
                StringWriter writer = new StringWriter();
                string serilizedString = Serializer.SerializeString(obj, types);
                string processedString;
                if(processSerialization != null)
                { 
                    processedString = processSerialization?.OnSave(serilizedString, AdditionalSettings); 
                }
                else
                {
                    processedString = serilizedString;
                }
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
                string result;
                if (processSerialization != null)
                {
                    result = processSerialization.OnLoad(source);
                }
                else
                {
                    result = source;
                }
                info = (SaveInfo)Deserializer.DeserializeString(result, types);
            }
            finally
            {
                fin.Close();
            }
            return info;
        }
    }
}
