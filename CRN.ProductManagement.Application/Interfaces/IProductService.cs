using CRN.ProductManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRN.ProductManagement.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();

        Task<ProductDto?> GetByIdAsync(int id);

        Task<int> CreateAsync(CreateProductDto dto);

        Task<bool> UpdateAsync(int id, UpdateProductDto dto);

        Task<bool> DeleteAsync(int id);
    }
}
