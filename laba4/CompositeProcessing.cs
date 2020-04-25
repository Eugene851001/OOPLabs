using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace UniverseEditor
{
    class CompositeProcessing: ISerializationProcessing
    {
        List<ISerializationProcessing> serializationProcessings;

        public CompositeProcessing()
        {
            serializationProcessings = new List<ISerializationProcessing>();
        }

        public void Add(ISerializationProcessing processing)
        {
            serializationProcessings.Add(processing);
        }

        public bool Delete(ISerializationProcessing processing)
        {
            return serializationProcessings.Remove(processing);
        }

        public string OnSave(string source, byte additionalSettings)
        {
            foreach(var processer in serializationProcessings)
            {
                source = processer.OnSave(source, additionalSettings);
            }
            return source;
        }

        public string OnLoad(string source)
        {
            for(int i = serializationProcessings.Count - 1; i >=0; i--)
            {
                source = serializationProcessings[i].OnLoad(source);
            }
            return source;
        }

    }
}
