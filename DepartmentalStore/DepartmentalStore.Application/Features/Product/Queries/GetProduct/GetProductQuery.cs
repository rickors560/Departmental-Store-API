using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStore.Application.Features.Product.Queries.GetProduct
{
    public class GetProductQuery : IRequest<GetProductVM>
    {
        public int Id { get; set; }
        public bool IncludeInventory { get; set; }
        public bool IncludePrices { get; set; }
    }
}
