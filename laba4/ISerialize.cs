﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UniverseEditor
{
    interface ISerialize
    {
        void Serialize(object obj, string path, Type[] types);
        object Deserialize(string path, Type[] types);
    }
}
