using DepartmentalStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStore.Application.Features.Product.Queries.GetProducts
{
    public class GetProductsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortCode { get; set; }
        public string Manufacturer { get; set; }
        public int Quantity { get; set; }

        public GetProductsPriceDto Price { get; set; }
        public GetProductsInventoryDto Inventory { get; set; }
    }
}
