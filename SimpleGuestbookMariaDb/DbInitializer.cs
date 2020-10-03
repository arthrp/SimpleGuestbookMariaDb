using Dapper;
using Dapper.Contrib.Extensions;
using MySqlConnector;
using SimpleGuestbookMariaDb.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleGuestbookMariaDb
{
    public class DbInitializer
    {
        public void Init(string connectionString)
        {
            var sql = File.ReadAllText("DbStructure/InitDb.sql");

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                connection.Execute(sql);

                connection.Insert(new PostDto() { Posttext = "Hello", Username = "John", CreatedOn = DateTime.UtcNow });
            }


        }
    }
}
