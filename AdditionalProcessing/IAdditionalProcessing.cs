using System;
using System.IO;

namespace AdditionalProcessing
{
    public interface IAdditionalProcessing
    {
        void OnSave(byte[] data, string savePath);
        Stream OnLoad(string openPath);
    }
}
