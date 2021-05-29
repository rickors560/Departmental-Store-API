using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStore.Application.Features.Product.Queries.GetProduct
{
    public class GetProductPriceDto
    {
        public int PriceId { get; set; }
        public double CostPrice { get; set; }
        public double SellingPrice { get; set; }
        public DateTime EffectiveDate { get; set; }
    }
}
