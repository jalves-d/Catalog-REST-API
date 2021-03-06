using Catalog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Catalog.Repositories
{
    public class InMemItemsRepository : IItemsRepository
    {
        private readonly List<Item> items = new()
        {
            new Item{ Id = System.Guid.NewGuid(), Name = "Potion", Price = 9, Created = System.DateTimeOffset.UtcNow},
            new Item{ Id = System.Guid.NewGuid(), Name = "Iron Sword", Price = 20, Created = System.DateTimeOffset.UtcNow},
            new Item{ Id = System.Guid.NewGuid(), Name = "Bronze Shield", Price = 18, Created = System.DateTimeOffset.UtcNow}
        };
        public IEnumerable<Item> GetItems() 
        {
            return items;
        }
        public Item GetItem(Guid id)
        {
            return items.Where(x => x.Id == id).SingleOrDefault();
        }

        public void CreateItem(Item item)
        {
            items.Add(item);
        }

        public void UpdateItem(Item item)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
            items[index] = item;
        }

        public void DeleteItem(Guid id)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == id);
            items.RemoveAt(index);
        }
    }
}
