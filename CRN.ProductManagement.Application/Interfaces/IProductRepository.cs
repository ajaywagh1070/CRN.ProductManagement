using CRN.ProductManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRN.ProductManagement.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();

        Task<Product?> GetByIdAsync(int id);

        Task AddAsync(Product product);

        void Update(Product product);

        void Delete(Product product);
    }
}
