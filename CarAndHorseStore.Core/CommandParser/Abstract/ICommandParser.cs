﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarAndHorseStore.Core.CommandParser.Abstract
{
    public interface ICommandParser
    {
        string ParseCommand(string command );
        void Start();
        bool IsParsing { get; set; }
    }
}
