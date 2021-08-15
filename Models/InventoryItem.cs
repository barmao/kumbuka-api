using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kumbuka_api.Models
{
    public class InventoryItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        public long AddedBy { get; set; }
        public DateTime AddedOn { get; set; }
        public string Location { get; set; }

    }
}
