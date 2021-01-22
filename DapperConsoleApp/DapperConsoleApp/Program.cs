using CommandLine;
using System;

namespace DapperConsoleApp
{
    class Program
    {
        static int Main(string[] args)
        {
            return CommandLine.Parser.Default.ParseArguments<CreateOptions, ReadOptions, UpdateOptions, DeleteOptions>(args).MapResult(
                (CreateOptions addOpts) => CreateRecord(addOpts),
                (ReadOptions readOpts) => ReadRecord(readOpts),
                (UpdateOptions updateOpts) => UpdateRecord(updateOpts),
                (DeleteOptions deleteOpts) => DeleteRecord(deleteOpts),
                errs => 1
                );
        }

        private static int CreateRecord(CreateOptions addOpts)
        {
            Console.WriteLine($"CreateRecord is called with fields = {string.Join(",", addOpts.Fields)}.");
            return 0;
        }

        private static int ReadRecord(ReadOptions readOpts)
        {
            Console.WriteLine($"ReadRecord is called with name = {readOpts.Name}.");
            return 0;
        }

        private static int UpdateRecord(UpdateOptions updateOpts)
        {
            Console.WriteLine($"UpdateRecord is called with fields = {string.Join(",", updateOpts.Fields)}.");
            return 0;
        }

        private static int DeleteRecord(DeleteOptions deleteOpts)
        {
            Console.WriteLine($"DeleteRecord is called with name = {deleteOpts.Name}.");
            return 0;
        }
    }
}
