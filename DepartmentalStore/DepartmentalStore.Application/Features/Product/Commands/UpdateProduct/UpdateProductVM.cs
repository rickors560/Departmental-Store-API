using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStore.Application.Features.Product.Commands.UpdateProduct
{
    public class UpdateProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortCode { get; set; }
        public string Manufacturer { get; set; }
        public int Quantity { get; set; }
    }
}
