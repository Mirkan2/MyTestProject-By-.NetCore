using Dapper;
using Microsoft.Extensions.Configuration;
using MyTestProject.Models;
using MyTestProject.Services;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace MyTestProject.Data
{
    public class DataAccess : IDataAccess
    {
        private readonly IConfiguration _configuration;

        public DataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string query = "SELECT * FROM Items";
                return await db.QueryAsync<Item>(query);
            }
        }

        public async Task AddItemAsync(Item item)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string query = "INSERT INTO Items (Name, Price) VALUES (@Name, @Price)";
                await db.ExecuteAsync(query, item);
            }
        }
    }
}
