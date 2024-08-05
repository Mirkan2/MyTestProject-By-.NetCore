using MyTestProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTestProject.Repositories
{
    public interface IItemRepository
    {
        Task<int> AddItemAsync(Item item);
        Task<bool> DeleteItemAsync(int id);
        Task<bool> UpdateItemAsync(Item item);
        Task<IEnumerable<Item>> GetItemsAsync();
    }
}
