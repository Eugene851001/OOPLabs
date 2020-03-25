using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using Universe;

namespace OOPLaba3
{
    class SerializerXml: ISerialize
    {
        public void Serialize(object obj, string path)
        {
           
            FileStream fout = new FileStream(path, FileMode.Create);
            try
            {
                XmlSerializer formatter = new XmlSerializer(typeof(SaveInfo));
                formatter.Serialize(fout, obj);
            }
            finally
            {
                fout.Close();
            }

        }

        public object Deserialize(string path)
        {
            FileStream fin = new FileStream(path, FileMode.Open);
            SaveInfo info;
            try
            {
                XmlSerializer formatter = new XmlSerializer(typeof(SaveInfo));
                info = (SaveInfo)formatter.Deserialize(fin);
            }
            finally
            {
                fin.Close();
            }
            return info;
        }
    }
}
