using System;
using System.IO;
using AdditionalProcessing;
using System.IO.Compression;

namespace ArchivedAdditionalProcessing
{
    public class ArchivedAdditionalProcessing : IAdditionalProcessing
    {
        public Stream OnLoad(string openPath)
        {
            var sourceStream = new FileStream(openPath, FileMode.OpenOrCreate);
            var compressionStream = new GZipStream(sourceStream, CompressionMode.Decompress);
            return compressionStream;
        }

        public void OnSave(byte[] data, string savePath)
        {
            using (var targetStream = new FileStream(savePath, FileMode.Create))
            using (var compressionStream = new GZipStream(targetStream, CompressionMode.Compress))
            {
                compressionStream.Write(data, 0, data.Length);
            }
        }
    }
}
