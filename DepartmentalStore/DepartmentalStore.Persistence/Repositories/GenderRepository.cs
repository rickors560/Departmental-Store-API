using DepartmentalStore.Application.Contracts.Persistence;
using DepartmentalStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStore.Persistence.Repositories
{
    public class GenderRepository : BaseRepository<Gender>, IGenderRepository
    {
        public GenderRepository(DepartmentalStoreDbContext context) : base(context)
        {

        }
    }
}
