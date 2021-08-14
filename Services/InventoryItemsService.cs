using kumbuka_api.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kumbuka_api.Services
{
    public class InventoryItemsService
    {
        private readonly IMongoCollection<InventoryItem> _inventoryItems;

        public InventoryItemsService(IInventoryItemsDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _inventoryItems = database.GetCollection<InventoryItem>(settings.InventoryItemsCollectionName);
        }

        public List<InventoryItem> Get() =>
            _inventoryItems.Find(item => true).ToList();

        public InventoryItem Get(string id) =>
            _inventoryItems.Find<InventoryItem>(item => item.Id == id).FirstOrDefault();

        public InventoryItem Create(InventoryItem item)
        {
            _inventoryItems.InsertOne(item);
            return item;
        }

        public void Update(string id, InventoryItem itemIn) =>
            _inventoryItems.ReplaceOne(item => item.Id == id, itemIn);

        public void Remove(InventoryItem itemIn) =>
            _inventoryItems.DeleteOne(item => item.Id == itemIn.Id);

        public void Remove(string id) =>
            _inventoryItems.DeleteOne(item => item.Id == id);
    }
}
