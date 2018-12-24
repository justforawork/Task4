using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task4.Models;

namespace Task4.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Лаб 1", Description="This is an Лаб 1 description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Лаб 2", Description="This is an Лаб 2 description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Лаб 3", Description="This is an Лаб 3 description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Лаб 4", Description="This is an Лаб 4 description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Лаб 5", Description="This is an Лаб 5 description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Лаб 6", Description="This is an Лаб 6 description." },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}