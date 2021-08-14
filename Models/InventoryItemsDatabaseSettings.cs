using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kumbuka_api.Models
{
    public class InventoryItemsDatabaseSettings : IInventoryItemsDatabaseSettings
    {
        public string InventoryItemsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IInventoryItemsDatabaseSettings
    {
        string InventoryItemsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
