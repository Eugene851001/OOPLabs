using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Universe;
using System.Security.Policy;
using System.Security.Permissions;

namespace UniverseEditor
{
    class AstroPluginLoader
    {
        public static List<Type> LoadPlugin(string fileName)
        {
            List<Type> astroTypes = null;
            if (IsValidPlugin(fileName))
            {
                astroTypes = new List<Type>();
                Type[] allTypes = null;
                try
                {
                    Assembly asm = Assembly.LoadFrom(fileName);
                    allTypes = asm.GetTypes();
                }
                catch(ReflectionTypeLoadException e)
                {
                    Exception[] exceptions = e.LoaderExceptions;
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
            }
            return astroTypes;
        }

        static bool IsEqual(byte[] first, byte[] second)
        {
            bool result = true;
            if (first.Length != second.Length)
                return false;
            for (int i = 0; i < first.Length; i++)
            {
                if (first[i] != second[i])
                {
                    result = false;
                    break;
                }
            }
            return result;
        }
        public static bool IsValidPlugin(string fileName)
        {
            try
            {
                AssemblyName asmName = AssemblyName.GetAssemblyName(fileName);
                AssemblyName selfAsmName = Assembly.GetExecutingAssembly().GetName();
                if (IsEqual(asmName.GetPublicKeyToken(), selfAsmName.GetPublicKeyToken()))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
