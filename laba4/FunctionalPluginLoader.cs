using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UniverseEditor
{
    class FunctionalPluginLoader
    {
        public static List<ISerializationProcessing> LoadPlugin(string fileName)
        {
            List<ISerializationProcessing> serializationHandlers = null;
            if (AstroPluginLoader.IsValidPlugin(fileName))
            {
                serializationHandlers = new List<ISerializationProcessing>();
                Type[] allTypes = null;
                try
                {
                    Assembly asm = Assembly.LoadFrom(fileName);
                    allTypes = asm.GetTypes();
                }
                catch (ReflectionTypeLoadException e)
                {
                    Exception[] exceptions = e.LoaderExceptions;
                    allTypes = null;//not necessary
                }
                if (allTypes != null)
                {
                    foreach (Type type in allTypes)
                    {
                        var Instance = Activator.CreateInstance(type);
                        if (Instance is ISerializationProcessing)
                        {
                            serializationHandlers.Add(Instance as ISerializationProcessing);
                        }
                    }
                }
            }
            return serializationHandlers;
        }
    }
}
