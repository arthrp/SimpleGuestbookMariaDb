using Dapper.Contrib.Extensions;
using MySqlConnector;
using SimpleGuestbookMariaDb.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleGuestbookMariaDb.Repositories
{
    public class PostsRepository
    {
        private readonly string _connectionString;
        public PostsRepository(AppSettings settings) 
        {
            _connectionString = settings.ConnectionString;
        }

        public List<PostDto> GetAll()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                var result = connection.GetAll<PostDto>();

                connection.Close();

                return result.ToList();
            }
        }

        public void Add(PostDto post)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                connection.Insert<PostDto>(post);

                connection.Close();
            }
        }
    }
}
