using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace UniverseEditor
{
    class SerializerJson: ISerialize
    {
        public void Serialize(object obj, string path, Type[] types)
        {

            FileStream fout = new FileStream(path, FileMode.Create);
            try
            {
                string jsonString = JsonSerializer.Serialize(obj);
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
                string jsonString = "";
                byte[] buffer = new byte[fin.Length];
                fin.Read(buffer, 0, (int)fin.Length);
                jsonString = Encoding.ASCII.GetString(buffer);
                info = (SaveInfo)JsonSerializer.Deserialize(jsonString, typeof(SaveInfo));
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
