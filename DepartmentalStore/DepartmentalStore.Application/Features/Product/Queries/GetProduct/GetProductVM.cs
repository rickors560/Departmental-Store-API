using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStore.Application.Features.Product.Queries.GetProduct
{
    public class GetProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortCode { get; set; }
        public string Manufacturer { get; set; }
        public int Quantity { get; set; }

        public List<GetProductPriceDto> Prices { get; set; }
        public GetProductInventoryDto Inventory { get; set; }
    }
}
