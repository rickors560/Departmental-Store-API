using DepartmentalStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStore.Application.Contracts.Persistence
{
    public interface IProductSupplierRepository : IAsyncRepository<ProductSupplier>
    {
        
    }
}
