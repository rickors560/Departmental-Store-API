using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStore.Application.Features.Product.Queries.GetProducts
{
    public class GetProductsQuery : IRequest<List<GetProductsVM>>
    {
        public bool IncludeInventory { get; set; }
        public bool IncludePrice { get; set; }
    }
}
