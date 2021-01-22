using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace DapperConsoleApp
{
    [Verb("update", HelpText = "Update a record.")]
    public class UpdateOptions
    {
        [Option('n', "name", Required = false, HelpText = "name to be added.")]
        public string Name { get; set; }
        [Option('f', "fields", Required = false, HelpText = "fields to be added.")]
        public IEnumerable<string> Fields { get; set; }
    }
}
