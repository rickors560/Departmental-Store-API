using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStore.Application.Features.Product.Queries.GetProduct
{
    public class GetProductInventoryDto
    {
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
