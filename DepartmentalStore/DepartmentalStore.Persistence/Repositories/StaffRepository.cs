using DepartmentalStore.Application.Contracts.Persistence;
using DepartmentalStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStore.Persistence.Repositories
{
    public class StaffRepository : BaseRepository<Staff>, IStaffRepository
    {
        public StaffRepository(DepartmentalStoreDbContext context) : base(context)
        {

        }

        public async Task<Staff> GetByIdWithAddressAsync(int id, bool includeAddress)
        {
            var staff = _context.Staff
                .Include(x => x.Gender)
                .Include(x => x.Role);

            if (includeAddress)
            {
                var staffWithAddress = staff.Include(x => x.Address).SingleAsync(x => x.Id == id);
                return await staffWithAddress;
            }
            return await staff.SingleAsync(x => x.Id == id);
        }

        public async Task<ICollection<Staff>> GetStaffsWithAddress(bool includeAddress)
        {
            var staffs = _context.Staff
                .Include(x => x.Gender)
                .Include(x => x.Role);
            if (includeAddress)
            {
                var staffsWithAddress = staffs.Include(x => x.Address);
                return await staffsWithAddress.ToListAsync();
            }
            return await staffs.ToListAsync();
        }
    }
}
