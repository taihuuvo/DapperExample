using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace DapperConsoleApp
{
    [Verb("delete", HelpText = "Delete a record.")]
    public class DeleteOptions
    {
        [Option('n', "name", Required = false, HelpText = "name of record to be deleted.")]
        public string Name { get; set; }
    }
}
