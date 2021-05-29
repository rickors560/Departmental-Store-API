using DepartmentalStore.Application.Contracts.Persistence;
using DepartmentalStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStore.Persistence.Repositories
{
    public class OrderDetailRepository : BaseRepository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(DepartmentalStoreDbContext context) : base(context)
        {

        }
    }
}
