using DepartmentalStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStore.Application.Contracts.Persistence
{
    public interface IStaffRepository : IAsyncRepository<Staff>
    {
        Task<ICollection<Staff>> GetStaffsWithAddress(bool includeAddress);
        Task<Staff> GetByIdWithAddressAsync(int id, bool includeAddress);
    }
}
