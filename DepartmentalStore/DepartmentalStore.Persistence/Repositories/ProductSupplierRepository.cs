using DepartmentalStore.Application.Contracts.Persistence;
using DepartmentalStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStore.Persistence.Repositories
{
    public class ProductSupplierRepository : BaseRepository<ProductSupplier>, IProductSupplierRepository
    {
        public ProductSupplierRepository(DepartmentalStoreDbContext context) : base(context)
        {

        }
    }
}
