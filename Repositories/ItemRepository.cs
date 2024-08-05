using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
using MyTestProject.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTestProject.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly IConfiguration _configuration;

        public ItemRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Saklı yordam kullanarak veri ekleme
        public async Task<int> AddItemAsync(Item item)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            var sql = "AddItem"; // Saklı yordam adı
            var parameters = new { Name = item.Name };
            return await connection.QuerySingleAsync<int>(sql, parameters, commandType: CommandType.StoredProcedure);
        }

        // Saklı yordam kullanarak veri silme
        public async Task<bool> DeleteItemAsync(int id)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            var sql = "DeleteItem"; // Saklı yordam adı
            var parameters = new { Id = id };
            var result = await connection.ExecuteAsync(sql, parameters, commandType: CommandType.StoredProcedure);
            return result > 0; // Silme başarılıysa true döndür
        }

        // Doğrudan SQL sorgusu kullanarak veri silme
        public async Task<bool> DeleteItemDirectAsync(int id)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            var sql = "DELETE FROM Items WHERE Id = @Id";
            var result = await connection.ExecuteAsync(sql, new { Id = id });
            return result > 0; // Silme başarılıysa true döndür
        }

        // Saklı yordam kullanarak veri güncelleme
        public async Task<bool> UpdateItemAsync(Item item)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            var sql = "UpdateItem"; // Saklı yordam adı
            var parameters = new { Id = item.Id, Name = item.Name };
            var result = await connection.ExecuteAsync(sql, parameters, commandType: CommandType.StoredProcedure);
            return result > 0; // Güncelleme başarılıysa true döndür
        }

        // Doğrudan SQL sorgusu kullanarak veri güncelleme
        public async Task<bool> UpdateItemDirectAsync(Item item)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            var sql = "UPDATE Items SET Name = @Name WHERE Id = @Id";
            var result = await connection.ExecuteAsync(sql, new { Id = item.Id, Name = item.Name });
            return result > 0; // Güncelleme başarılıysa true döndür
        }

        // Doğrudan SQL sorgusu kullanarak veri ekleme
        public async Task<int> AddItemDirectAsync(Item item)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            var sql = "INSERT INTO Items (Name) VALUES (@Name); SELECT CAST(SCOPE_IDENTITY() AS INT);";
            return await connection.QuerySingleAsync<int>(sql, new { Name = item.Name });
        }

        // Saklı yordam kullanarak veri getirme
        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            var sql = "GetItems"; // Saklı yordam adı
            return await connection.QueryAsync<Item>(sql, commandType: CommandType.StoredProcedure);
        }

        // Doğrudan SQL sorgusu kullanarak veri getirme
        public async Task<IEnumerable<Item>> GetItemsDirectAsync()
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            var sql = "SELECT * FROM Items";
            return await connection.QueryAsync<Item>(sql);
        }
    }
}
