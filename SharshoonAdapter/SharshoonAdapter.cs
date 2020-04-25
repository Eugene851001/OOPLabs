using System;
using UniverseEditor;
using System.Text;
using System.IO;
using AdditionalProcessing;

namespace FunctionalPluginAdapter
{
    public class SharshoonAdapter: ISerializationProcessing
    {
        IAdditionalProcessing additionalProcessing;
        string bufferFileName = "temp.txt";

        public SharshoonAdapter(IAdditionalProcessing processing)
        {
            additionalProcessing = processing;
        }

        public string OnSave(string source, byte additionalSettings)
        {
            additionalProcessing.OnSave(Encoding.ASCII.GetBytes(source), bufferFileName);
            FileStream fout = new FileStream(bufferFileName, FileMode.Open);
            byte[] buffer = new byte[fout.Length];
            fout.Read(buffer, 0, (int)fout.Length);
            fout.Close();
            return Encoding.ASCII.GetString(buffer);
        }

        public string OnLoad(string source)
        {
            Stream stream = additionalProcessing.OnLoad(bufferFileName);
            MemoryStream container = new MemoryStream();
            stream.CopyTo(container);
            container.Position = 0;
            byte[] buffer = new byte[container.Length];
            container.Read(buffer, 0, (int)container.Length);
            return Encoding.ASCII.GetString(buffer);
        }

    }
}
