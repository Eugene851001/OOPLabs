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
        public List<AstronomicalObject> AstroObjects { get { return astroObjects; } }
        SerializerXml serializer = new SerializerXml();
        List<Type> types = new List<Type>();

        public void AddTypes(List<Type> types)
        {
            foreach(var type in types)
            {
                if (!this.types.Contains(type))
                    this.types.Add(type);
            }
        }

        public void ChangeFileName(string fileName)
        {
            FileName = fileName;
        }
        
        public void Add(AstronomicalObject obj, Dictionary<int, EditObject> astroEditors,
            Dictionary<int, EditObject> astroHashEditors)
        {
            if (!types.Contains(obj.GetType()))
                types.Add(obj.GetType());
            astroObjects.Add(obj);
            SaveInfo info = new SaveInfo(astroObjects, astroEditors, astroHashEditors);
            serializer.Serialize(info, FileName, types.ToArray());
        }

        public SaveInfo GetAll()
        {
            SaveInfo info = null;
            info = (SaveInfo)serializer.Deserialize(FileName, types.ToArray());
            if (info == null)
                return info;
            astroObjects = info.AstroObjects;
            foreach(AstronomicalObject astroObject in astroObjects)
            {
                if (astroObject is IParticle)
                {
                    ((IParticle)astroObject).MainObject = GetParent(((IParticle)astroObject).MainObject.uid);
                    if(((IParticle)astroObject).MainObject != null)
                    {
                        ((IParticle)astroObject).AddToParent();
                    }
                }
            }
            return info;
        }

        void HelpDeleteObject(AstronomicalObject astroObject)
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

        void DeleteObject(AstronomicalObject astroObject)
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
                UpdateObjects();
                SaveInfo info = new SaveInfo(astroObjects, astroEditors, astroHashEditors);
                serializer.Serialize(info, FileName, types.ToArray());
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

        AstronomicalObject GetParent(int uid)
        {
            bool IsFound = false;
            int i;
            for (i = 0; !IsFound && i < astroObjects.Count; i++)
            {
                if (astroObjects[i].uid == uid)
                    IsFound = true;
            }
            if (!IsFound)
                return null;
            return astroObjects[i - 1];
        }
        public void RemoveAll()
        {
            astroObjects.Clear();
            FileStream fout = new FileStream(FileName, FileMode.Create);
            fout.Close();
        }
    }
}
