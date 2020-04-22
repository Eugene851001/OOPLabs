using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Runtime.Serialization.Json;

namespace UniverseEditor
{
    class SerializerJson: ISerialize
    {
        public void Serialize(object obj, string path, Type[] types)
        {

            FileStream fout = new FileStream(path, FileMode.Create);
            try
            {
                string jsonString = JsonSerializer.Serialize(obj, new JsonSerializerOptions() { WriteIndented = true});
                fout.Write(Encoding.ASCII.GetBytes(jsonString), 0, Encoding.ASCII.GetBytes(jsonString).Length);
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
                var jsonSerializer = new DataContractJsonSerializer(typeof(SaveInfo), types);
                info = (SaveInfo)jsonSerializer.ReadObject(fin);
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
