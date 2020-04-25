using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using Universe;

namespace UniverseEditor
{
    class SerializerXml: ISerialize, IStringSerialize
    {

        public string SerializeString(object obj, Type[] types)
        {
            MemoryStream stream = new MemoryStream();
            XmlSerializer formatter = new XmlSerializer(typeof(SaveInfo), types);
            formatter.Serialize(stream, obj);
            string result = Encoding.ASCII.GetString(stream.ToArray());
            return result;
        }

        public object DeserializeString(string source, Type[] types)
        {
            MemoryStream stream = new MemoryStream(Encoding.ASCII.GetBytes(source));
            XmlSerializer formatter = new XmlSerializer(typeof(SaveInfo), types);
            SaveInfo info = (SaveInfo)formatter.Deserialize(stream);
            return info;
        }

        public void Serialize(object obj, string path, Type[] types)
        {
            FileStream fout = new FileStream(path, FileMode.Create);
            try
            {
                XmlSerializer formatter = new XmlSerializer(typeof(SaveInfo), types);
                formatter.Serialize(fout, obj);
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
                XmlSerializer formatter = new XmlSerializer(typeof(SaveInfo), types);
                info = (SaveInfo)formatter.Deserialize(fin);
            }
            catch
            {
                info = null;
            }
            finally
            {
                fin.Close();
            }
            return info;
        }
    }
}
