using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace DapperConsoleApp
{
    [Verb("update", HelpText = "Update a record.")]
    public class UpdateOptions
    {
        [Option('n', "name", Required = true, HelpText = "name client to be updated.")]
        public string Name { get; set; }
        [Option('f', "fields", Required = true, HelpText = "fields to be updated.")]
        public IEnumerable<string> Fields { get; set; }
    }
}
