using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
           //     string processedString = processSerialization.OnSave(
             //       "<AstroObjects><AstronomicalObject><Name>Sun</Name></AstronomicalObject>" +
               //     "<AstronomicalObject><Name>Earth</Name></AstronomicalObject></AstroObjects>" +
                 //   "<UidHash><AstroObjectsEditors><uid>0</uid><hash>1</hash>"+ 
                   // "AstroObjectsEditors</UidHash>", AdditionalSettings);
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
            return this;
        }
    }
}
