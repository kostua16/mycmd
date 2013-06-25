using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CmdLine;

namespace mycmd
{
    [CommandLineArguments(Program = "mycmd",Description = "cmdline",Title = "Welcome to mycmd")]
    class SimpleArgs
    {
        [CommandLineParameter(Command = "?",Default = false,Description = "Show Help",Name = "Help",IsHelp = true)]
        public bool Help { get; set; }
        [CommandLineParameter(Name = "runFile",ParameterIndex = 1, Required=true, Description = "Specifies the file to run.")]
        public string RunFile { get; set; }
    }
}
