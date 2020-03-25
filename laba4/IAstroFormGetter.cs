using OOPLaba3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Universe;

namespace UniverseEditor
{
    interface IAstroFormGetter
    {
        frmEditAstro GetForm(Type astroType, AstronomicalObject obj);
    }
}
