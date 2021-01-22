using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace DapperConsoleApp
{
    [Verb("create", HelpText = "Create a record.")]
    public class CreateOptions
    {
        [Option('f', "fields", Required = false, HelpText = "fields to be added.")]
        public IEnumerable<string> Fields { get; set; }
    }
}
