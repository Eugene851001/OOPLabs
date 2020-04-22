using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universe;

namespace UniverseEditor
{
    interface IService
    {
        void Add(AstronomicalObject obj, Dictionary<int, EditObject> astroEditors,
            Dictionary<int, EditObject> astroHashEditors);
        bool Remove(AstronomicalObject obj, Dictionary<int, EditObject> astroEditors,
            Dictionary<int, EditObject> astroHashEditors);

        SaveInfo GetAll();
        void RemoveAll();
    }
}
