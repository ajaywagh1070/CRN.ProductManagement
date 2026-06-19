using CRN.ProductManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRN.ProductManagement.Application.Interfaces
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetAllAsync();

        Task<Item?> GetByIdAsync(int id);

        Task AddAsync(Item item);

        void Update(Item item);

        void Delete(Item item);
    }
}
