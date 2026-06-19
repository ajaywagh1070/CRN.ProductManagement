using CRN.ProductManagement.Application.DTOs;

namespace CRN.ProductManagement.Application.Interfaces;

public interface IItemService
{
    Task<IEnumerable<ItemDto>> GetAllAsync();

    Task<ItemDto?> GetByIdAsync(int id);

    Task<int> CreateAsync(CreateItemDto dto);

    Task<bool> UpdateAsync(int id, UpdateItemDto dto);

    Task<bool> DeleteAsync(int id);
}