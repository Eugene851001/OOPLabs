﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniverseEditor
{
    public interface ISerializationProcessing
    {
        string OnSave(string source);

        string OnLoad(string source);
    }
}