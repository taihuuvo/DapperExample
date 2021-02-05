using CommandLine;
using Dapper;
using System;
using System.Data.SqlClient;

namespace DapperConsoleApp
{
    //References:
    //  https://github.com/commandlineparser/commandline
    //  https://github.com/StackExchange/Dapper
    //  https://zetcode.com/csharp/dapper/
    class Program
    {
        private const string _connectionString = @"Server=localhost;Database=testdb;Trusted_Connection=True;";
        private SqlConnection _connection;

        static int Main(string[] args)
        {
            var program = new Program();
            program.InitDb();

            var retVal = CommandLine.Parser.Default.ParseArguments<CreateOptions, ReadOptions, UpdateOptions, DeleteOptions>(args).MapResult(
                (CreateOptions addOpts) => program.CreateRecord(addOpts),
                (ReadOptions readOpts) => program.ReadRecord(readOpts),
                (UpdateOptions updateOpts) => program.UpdateRecord(updateOpts),
                (DeleteOptions deleteOpts) => program.DeleteRecord(deleteOpts),
                errs => 1
                );

            program.CloseDb();

            return retVal;
        }
        
        private void InitDb()
        {
            _connection = new SqlConnection(_connectionString);
            _connection.Open();
        }

        private void CloseDb()
        {
            _connection.Close();
        }


        //example command: create -f name1 info1
        private int CreateRecord(CreateOptions addOpts)
        {
            var fields = addOpts.Fields.AsList<string>();
            Console.WriteLine($"CreateRecord is called with fields = {string.Join(",", fields)}.");
            var retVal = _connection.Execute("INSERT INTO Client(Name, Information) VALUES (@name, @information)", new { name = fields[0], information = fields[1] });
            return retVal != 0 ? 0 : 1;
        }

        //example command: read -n name1
        private int ReadRecord(ReadOptions readOpts)
        {
            Console.WriteLine($"ReadRecord is called with name = {readOpts.Name}.");
            var clients = _connection.Query<Client>("SELECT * FROM Client WHERE Name = @name", new { name = readOpts.Name }).AsList<Client>();
            clients.ForEach(cl => Console.WriteLine($"{cl.Name}, {cl.Information}"));

            return clients.Count > 0 ? 0 : 2;
        }

        //example command: update -n name1 -f info1b
        private int UpdateRecord(UpdateOptions updateOpts)
        {
            var fields = updateOpts.Fields.AsList<string>();
            Console.WriteLine($"UpdateRecord is called with name = {updateOpts.Name}, fields = {string.Join(",", fields)}.");
            var execParams = new DynamicParameters();
            execParams.Add("@name", updateOpts.Name, System.Data.DbType.String, System.Data.ParameterDirection.Input, 255);
            execParams.Add("@information", fields[0]);
            var retVal = _connection.Execute("UPDATE Client SET Information = @information WHERE Name = @name", execParams);
            return retVal != 0 ? 0 : 3;
        }

        //example command: delete -n name1
        private int DeleteRecord(DeleteOptions deleteOpts)
        {
            Console.WriteLine($"DeleteRecord is called with name = {deleteOpts.Name}.");
            var retVal = _connection.Execute("DELETE Client WHERE Name = @name", new { name = deleteOpts.Name });
            return retVal != 0 ? 0 : 4; 
        }
    }
}
