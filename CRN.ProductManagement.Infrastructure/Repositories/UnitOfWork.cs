using CRN.ProductManagement.Application.Interfaces;
using CRN.ProductManagement.Infrastructure.Data;

namespace CRN.ProductManagement.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public IProductRepository Products { get; }

    public IItemRepository Items { get; }

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;

        Products = new ProductRepository(context);

        Items = new ItemRepository(context);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}