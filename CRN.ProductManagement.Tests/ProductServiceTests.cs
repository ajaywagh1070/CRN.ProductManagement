using CRN.ProductManagement.Application.DTOs;
using CRN.ProductManagement.Application.Interfaces;
using CRN.ProductManagement.Application.Services;
using CRN.ProductManagement.Domain.Entities;
using Moq;

namespace CRN.ProductManagement.Tests;

public class ProductServiceTests
{
    [Fact]
    public async Task GetByIdAsync_Returns_Product_When_Product_Exists()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();

        mockUnitOfWork.Setup(x => x.Products.GetByIdAsync(1))
            .ReturnsAsync(new Product
            {
                Id = 1,
                ProductName = "Laptop"
            });

        var service =
            new ProductService(mockUnitOfWork.Object);

        // Act
        var result =
            await service.GetByIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
        Assert.Equal("Laptop", result.ProductName);
    }
    [Fact]
    public async Task GetByIdAsync_Returns_Null_When_Product_Does_Not_Exist()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();

        mockUnitOfWork.Setup(x => x.Products.GetByIdAsync(999))
            .ReturnsAsync((Product?)null);

        var service =
            new ProductService(mockUnitOfWork.Object);

        // Act
        var result =
            await service.GetByIdAsync(999);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task DeleteAsync_Returns_True_When_Product_Exists()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();

        mockUnitOfWork.Setup(x => x.Products.GetByIdAsync(1))
            .ReturnsAsync(new Product
            {
                Id = 1,
                ProductName = "Laptop"
            });

        var service =
            new ProductService(mockUnitOfWork.Object);

        // Act
        var result =
            await service.DeleteAsync(1);

        // Assert
        Assert.True(result);
    }
}