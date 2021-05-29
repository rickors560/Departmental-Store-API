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
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(DepartmentalStoreDbContext context) : base(context)
        {

        }

        public async Task<ICollection<Product>> GetStaffsWithInventoryAndPrice(bool includeInventory, bool includePrice)
        {
            var products = _context.Product;

            if (includePrice && includeInventory)
            {
                var productsWithInventoryAndPrice = products
                    .Include(x => x.Inventory)
                    .Include(x => x.Prices)
                    .ToListAsync();
                return await productsWithInventoryAndPrice;
            }

            if (includeInventory)
            {
                var productsWithInventory = products.Include(x => x.Inventory);
                return await productsWithInventory.ToListAsync();
            }

            if (includePrice)
            {
                var productsWithPrices = products.Include(x => x.Prices);
                return await productsWithPrices.ToListAsync();
            }

            return await products.ToListAsync();
        }

        public async Task<Product> GetStaffWithInventoryAndPrice(int id, bool includeInventory, bool includePrice)
        {
            var product = _context.Product;

            if (includePrice && includeInventory) { 
                var productWithInventoryAndPrice = product
                    .Include(x => x.Inventory)
                    .Include(x => x.Prices)
                    .SingleAsync(x => x.Id == id);
                return await productWithInventoryAndPrice;
            }

            if (includeInventory)
            {
                var productWithInventory = product.Include(x => x.Inventory).SingleAsync(x => x.Id == id);
                return await productWithInventory;
            }

            if (includePrice)
            {
                var productWithPrices = product.Include(x => x.Prices).SingleAsync(x => x.Id == id);
                return await productWithPrices;
            }

            return await product.SingleAsync(x => x.Id == id);
        }
    }
}
