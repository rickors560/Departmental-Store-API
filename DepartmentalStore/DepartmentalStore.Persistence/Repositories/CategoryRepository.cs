using DepartmentalStore.Application.Contracts.Persistence;
using DepartmentalStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStore.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DepartmentalStoreDbContext context) : base(context)
        {

        }
    }
}
