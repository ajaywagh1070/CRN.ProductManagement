using CRN.ProductManagement.Application.DTOs;
using CRN.ProductManagement.Application.Interfaces;
using CRN.ProductManagement.Domain.Entities;

namespace CRN.ProductManagement.Application.Services;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PagedResponse<ProductDto>> GetAllAsync(
    int page,
    int pageSize)
    {
        var products = await _unitOfWork.Products.GetAllAsync();

        var totalRecords = products.Count();

        var pagedProducts = products
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(x => new ProductDto
            {
                Id = x.Id,
                ProductName = x.ProductName
            });

        return new PagedResponse<ProductDto>
        {
            Page = page,
            PageSize = pageSize,
            TotalRecords = totalRecords,
            Data = pagedProducts
        };
    }

    public async Task<ProductDto?> GetByIdAsync(int id)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(id);

        if (product == null)
            return null;

        return new ProductDto
        {
            Id = product.Id,
            ProductName = product.ProductName
        };
    }

    public async Task<int> CreateAsync(CreateProductDto dto)
    {
        var product = new Product
        {
            ProductName = dto.ProductName,
            CreatedBy = "System",
            CreatedOn = DateTime.UtcNow
        };

        await _unitOfWork.Products.AddAsync(product);

        await _unitOfWork.SaveChangesAsync();

        return product.Id;
    }

    public async Task<bool> UpdateAsync(int id, UpdateProductDto dto)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(id);

        if (product == null)
            return false;

        product.ProductName = dto.ProductName;
        product.ModifiedBy = "System";
        product.ModifiedOn = DateTime.UtcNow;

        _unitOfWork.Products.Update(product);

        await _unitOfWork.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(id);

        if (product == null)
            return false;

        _unitOfWork.Products.Delete(product);

        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}