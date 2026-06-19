using CRN.ProductManagement.Application.Interfaces;
using CRN.ProductManagement.Domain.Entities;
using CRN.ProductManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CRN.ProductManagement.Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext _context;

    public ItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<Item?> GetByIdAsync(int id)
        {
            return await _context.Items
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Item item)
        {
            await _context.Items.AddAsync(item);
        }

        public void Update(Item item)
        {
            _context.Items.Update(item);
        }

        public void Delete(Item item)
        {
            _context.Items.Remove(item);
        }
    }


}
