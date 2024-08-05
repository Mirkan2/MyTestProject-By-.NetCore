using System.Collections.Generic;
using MyTestProject.Models;

namespace MyTestProject.Services
{
    public interface IDataAccess
    {
        Task<IEnumerable<Item>> GetItemsAsync();
        Task AddItemAsync(Item item);
    }
}
