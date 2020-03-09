using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universe;

namespace OOPLaba3
{
    public delegate void EditObject(AstronomicalObject obj);

    public class UidHash
    {
        public int Uid;
        public int Hash;

        public UidHash()
        {
            Uid = Hash = 0;
        }

        public UidHash(int uid, int hash)
        {
            Uid = uid;
            Hash = hash;
        }
    }

    public class SaveInfo
    {
        public List<AstronomicalObject> AstroObjects;
        public List<UidHash> AstroObjectsEditors;//

        public SaveInfo()
        {
            AstroObjects = new List<AstronomicalObject>();
            AstroObjectsEditors = new List<UidHash>();
        }

        public SaveInfo(List<AstronomicalObject> astroObjects, Dictionary<int, 
            EditObject> astroEditors, Dictionary<int, EditObject> astroHashEditors)
        {
            AstroObjects = new List<AstronomicalObject>();
            foreach (AstronomicalObject obj in astroObjects)
            {
                AstroObjects.Add(obj);
            }
            AstroObjectsEditors = new List<UidHash>();
            foreach(int uid  in astroEditors.Keys)
            {
                foreach(int hash in astroHashEditors.Keys)
                {
                    if (astroEditors[uid] == astroHashEditors[hash])
                        AstroObjectsEditors.Add(new UidHash(uid, hash));
                }
            }
        }

        public Dictionary<int, EditObject> GetAstroEditors(Dictionary<int, EditObject> astroHashEditors)
        {
            Dictionary<int, EditObject> astroEditors = new Dictionary<int, EditObject>();
            Dictionary<int, int> astroObjectsEditors = AstroObjectsEditors.ToDictionary(n => n.Uid, n => n.Hash);
            foreach (var item in AstroObjectsEditors)
            {
                astroEditors.Add(item.Uid, astroHashEditors[astroObjectsEditors[item.Uid]]);
            }
            return astroEditors;
        }
    }
}
