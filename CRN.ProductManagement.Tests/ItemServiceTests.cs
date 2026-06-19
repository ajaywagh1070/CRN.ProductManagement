using CRN.ProductManagement.Application.Interfaces;
using CRN.ProductManagement.Application.Services;
using CRN.ProductManagement.Domain.Entities;
using Moq;

namespace CRN.ProductManagement.Tests;

public class ItemServiceTests
{
    [Fact]
    public async Task GetByIdAsync_Returns_Item_When_Item_Exists()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();

        mockUnitOfWork.Setup(x => x.Items.GetByIdAsync(1))
            .ReturnsAsync(new Item
            {
                Id = 1,
                ProductId = 100,
                Quantity = 5
            });

        var service =
            new ItemService(mockUnitOfWork.Object);

        // Act
        var result =
            await service.GetByIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
        Assert.Equal(100, result.ProductId);
        Assert.Equal(5, result.Quantity);
    }
    [Fact]
    public async Task GetByIdAsync_Returns_Null_When_Item_Does_Not_Exist()
    {
        var mockUnitOfWork = new Mock<IUnitOfWork>();

        mockUnitOfWork.Setup(x => x.Items.GetByIdAsync(999))
            .ReturnsAsync((Item?)null);

        var service =
            new ItemService(mockUnitOfWork.Object);

        var result =
            await service.GetByIdAsync(999);

        Assert.Null(result);
    }
    [Fact]
    public async Task DeleteAsync_Returns_True_When_Item_Exists()
    {
        var mockUnitOfWork = new Mock<IUnitOfWork>();

        mockUnitOfWork.Setup(x => x.Items.GetByIdAsync(1))
            .ReturnsAsync(new Item
            {
                Id = 1,
                ProductId = 100,
                Quantity = 5
            });

        var service =
            new ItemService(mockUnitOfWork.Object);

        var result =
            await service.DeleteAsync(1);

        Assert.True(result);
    }
}   