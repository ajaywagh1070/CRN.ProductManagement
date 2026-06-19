using CRN.ProductManagement.Application.DTOs;

namespace CRN.ProductManagement.Application.Interfaces
{
    public interface IProductService
    {
        Task<PagedResponse<ProductDto>> GetAllAsync(
            int page,
            int pageSize);

        Task<ProductDto?> GetByIdAsync(int id);

        Task<int> CreateAsync(CreateProductDto dto);

        Task<bool> UpdateAsync(int id, UpdateProductDto dto);

        Task<bool> DeleteAsync(int id);
    }
}