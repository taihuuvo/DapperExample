using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace DapperConsoleApp
{
    [Verb("read", HelpText = "Read a record.")]
    public class ReadOptions
    {
        [Option('n', "name", Required = false, HelpText = "name to be added.")]
        public string Name { get; set; }
    }
}
