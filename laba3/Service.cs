using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Universe
{
    class Service: IService
    {
        const string FileName = "Service.txt";
        List<AstronomicalObject> astroObjects = new List<AstronomicalObject>();
        XmlSerializer serializer = new XmlSerializer(typeof(List<AstronomicalObject>));
        public void Add(AstronomicalObject obj)
        {
            astroObjects.Add(obj);
            FileStream fout = new FileStream(FileName, FileMode.OpenOrCreate);   
            try
            {
                serializer.Serialize(fout, astroObjects);
                
            }
            finally
            {
                fout.Close();
            }
        }

        public bool Remove(AstronomicalObject obj)
        {
            if (astroObjects.Remove(obj))
            {
                
                FileStream fout = new FileStream(FileName, FileMode.OpenOrCreate);
                bool result = true;
                try
                {
                    serializer.Serialize(fout, astroObjects);
                    astroObjects.Remove(obj);
                }
                catch
                {
                    result = false;
                }
                finally
                {
                    fout.Close();
                }
                return result;

            }
            else
                return false;
        }

        public void RemoveAll()
        {
            astroObjects.Clear();
            FileStream fout = new FileStream(FileName, FileMode.Create);
            fout.Close();
        }
    }
}
