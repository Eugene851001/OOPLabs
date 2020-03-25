using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Universe;

namespace UniverseEditor
{
    class AstroPluginLoader
    {
        public static List<Type> LoadPlugin(string fileName)
        {
            List<Type> astroTypes = new List<Type>();
            Type[] allTypes = null;
            try
            {
                Assembly asm = Assembly.LoadFrom(fileName);
                allTypes = asm.GetTypes();
            }
            catch
            {
                allTypes = null;//not necessary
            }
            if (allTypes != null)
            {
                foreach (Type type in allTypes)
                {
                    if (typeof(AstronomicalObject).IsAssignableFrom(type))
                    {
                        astroTypes.Add(type);
                    }
                }
            }
            return astroTypes;
        }
    }
}
