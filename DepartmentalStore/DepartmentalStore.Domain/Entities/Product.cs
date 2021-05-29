using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStore.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortCode { get; set; }
        public string Manufacturer { get; set; }
        public int Quantity { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }
        public ICollection<Price> Prices { get; set; }
        public ICollection<ProductSupplier> ProductSuppliers { get; set; }
        public Inventory Inventory { get; set; }
    }
}