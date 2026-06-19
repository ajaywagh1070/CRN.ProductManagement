using CRN.ProductManagement.Application.DTOs;
using CRN.ProductManagement.Application.Interfaces;
using CRN.ProductManagement.Domain.Entities;

namespace CRN.ProductManagement.Application.Services;

public class ItemService : IItemService
{
    private readonly IUnitOfWork _unitOfWork;

    public ItemService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ItemDto>> GetAllAsync()
    {
        var items = await _unitOfWork.Items.GetAllAsync();

        return items.Select(x => new ItemDto
        {
            Id = x.Id,
            ProductId = x.ProductId,
            Quantity = x.Quantity
        });
    }

    public async Task<ItemDto?> GetByIdAsync(int id)
    {
        var item = await _unitOfWork.Items.GetByIdAsync(id);

        if (item == null)
            return null;

        return new ItemDto
        {
            Id = item.Id,
            ProductId = item.ProductId,
            Quantity = item.Quantity
        };
    }

    public async Task<int> CreateAsync(CreateItemDto dto)
    {
        var item = new Item
        {
            ProductId = dto.ProductId,
            Quantity = dto.Quantity
        };

        await _unitOfWork.Items.AddAsync(item);

        await _unitOfWork.SaveChangesAsync();

        return item.Id;
    }

    public async Task<bool> UpdateAsync(int id, UpdateItemDto dto)
    {
        var item = await _unitOfWork.Items.GetByIdAsync(id);

        if (item == null)
            return false;

        item.Quantity = dto.Quantity;

        _unitOfWork.Items.Update(item);

        await _unitOfWork.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var item = await _unitOfWork.Items.GetByIdAsync(id);

        if (item == null)
            return false;

        _unitOfWork.Items.Delete(item);

        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}