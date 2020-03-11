using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using OOPLaba3;

namespace Universe
{
    class Service: IService
    {
        public string FileName = "Service.txt";
        public List<AstronomicalObject> astroObjects = new List<AstronomicalObject>();
        SerializerXml serializer = new SerializerXml();

        public void ChangeFileName(string fileName)
        {
            FileName = fileName;
        }
        
        public void Add(AstronomicalObject obj, Dictionary<int, EditObject> astroEditors,
            Dictionary<int, EditObject> astroHashEditors)
        {
            astroObjects.Add(obj);
            SaveInfo info = new SaveInfo(astroObjects, astroEditors, astroHashEditors);
            serializer.Serialize(info, FileName);
        }

        public SaveInfo GetAll()
        {
            SaveInfo info;
            info = (SaveInfo)serializer.Deserialize(FileName);
            astroObjects = info.AstroObjects;
            return info;
        }

        public void HelpDeleteObject(AstronomicalObject astroObject)
        {
            if (astroObject is IComplexObj)
            {
                var item = astroObject as IComplexObj;
                for (int i = 0; i < item.Count; i++)
                {
                    HelpDeleteObject((AstronomicalObject)item[i]);
                }
            }
            astroObject.IsDestroy = true;
        }

        public void DeleteObject(AstronomicalObject astroObject)
        {
            if (astroObject is IParticle)
            {
                var item = astroObject as IParticle;
                item.RemoveFromParent();
            }
            HelpDeleteObject(astroObject);

        }

        public bool Remove(AstronomicalObject obj, Dictionary<int, EditObject> astroEditors,
            Dictionary<int, EditObject> astroHashEditors)
        {
            if (astroObjects.Contains(obj))
            {
                DeleteObject(obj);
                astroObjects.Remove(obj);
                SaveInfo info = new SaveInfo(astroObjects, astroEditors, astroHashEditors);
                serializer.Serialize(info, FileName);
                return true;
            }
            else
                return false;
        }


        public void UpdateObjects()
        {
            int counter = 0;
            while (counter < astroObjects.Count)
            {
                AstronomicalObject item = astroObjects[counter];
                if (item != null && item.IsDestroy)
                {
                    astroObjects.Remove(item);
                }
                else
                {
                    counter++;
                }
            }
        }

        public void UpdateObjectList(AstronomicalObject obj)
        {
            if (obj is IComplexObj)
            {
                var item = obj as IComplexObj;
                for (int i = 0; i < item.Count; i++)
                {
                    UpdateObjectList((AstronomicalObject)item[i]);
                }
                if (obj.uid > astroObjects[astroObjects.Count - 1].uid)
                {
                    astroObjects.Add(obj);
                }
            }
        }


        public void RemoveAll()
        {
            astroObjects.Clear();
            FileStream fout = new FileStream(FileName, FileMode.Create);
            fout.Close();
        }
    }
}
