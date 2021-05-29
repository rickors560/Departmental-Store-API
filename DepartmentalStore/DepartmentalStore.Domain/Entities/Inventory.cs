using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStore.Domain.Entities
{
    public class Inventory
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int InventoryQuantity { get; set; }
        public bool InStock
        {
            get
            {
                return (InventoryQuantity == 0) ? false : true;
            }
        }
    }
}