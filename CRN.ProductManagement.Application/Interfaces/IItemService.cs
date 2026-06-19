using CRN.ProductManagement.Application.DTOs;

namespace CRN.ProductManagement.Application.Interfaces;

public interface IItemService
{
    Task<PagedResponse<ItemDto>> GetAllAsync(
        int page,
        int pageSize);

    Task<ItemDto?> GetByIdAsync(int id);

    Task<int> CreateAsync(CreateItemDto dto);

    Task<bool> UpdateAsync(int id, UpdateItemDto dto);

    Task<bool> DeleteAsync(int id);
}