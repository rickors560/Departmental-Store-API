using DepartmentalStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStore.Application.Contracts.Persistence
{
    public interface IProductRepository : IAsyncRepository<Product>
    {
        Task<ICollection<Product>> GetStaffsWithInventoryAndPrice(bool includeInventory, bool includePrice);
        Task<Product> GetStaffWithInventoryAndPrice(int id, bool includeInventory, bool includePrice);
    }
}
