using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStore.Domain.Entities
{
    public class Price
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public double CostPrice { get; set; }
        public double SellingPrice { get; set; }
        public DateTime EffectiveDate { get; set; }
    }
}