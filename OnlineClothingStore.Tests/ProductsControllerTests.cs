using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using OnlineClothingStore.Api.Controllers;
using OnlineClothingStore.Core;
using OnlineClothingStore.Data;
using Xunit;

namespace OnlineClothingStore.Tests;

public class ProductsControllerTests
{
    private readonly ProductsController _controller;
    private readonly IProductRepository _repository;
    private readonly StoreDbContext _context;

    public ProductsControllerTests()
    {
        var options = new DbContextOptionsBuilder<StoreDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
        _context = new StoreDbContext(options);
        _repository = new ProductRepository(_context);
        _controller = new ProductsController(_repository);
    }

    [Fact]
    public async Task CreateProduct_ValidProduct_ReturnsCreated()
    {
        var productDto = new ProductDto
        {
            Size = "M",
            Color = "Blue",
            Price = 29.99M, 
            Description = "A blue medium-sized shirt"
        };
        var result = await _controller.CreateProduct(productDto);
        var createdResult = Assert.IsType<CreatedAtActionResult>(result);
        Assert.Equal(201, createdResult.StatusCode);
        var product = Assert.IsType<Product>(createdResult.Value);
        Assert.Equal("M", product.Size);
    }

    [Fact]
    public async Task GetProduct_ExistingId_ReturnsOk()
    {
        var product = new Product { Size = "M", Color = "Blue", Price = 29.99M, Description = "A blue medium-sized shirt" };
        await _repository.AddAsync(product);
        var result = await _controller.GetProduct(product.Id);
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200, okResult.StatusCode);
        var returnedProduct = Assert.IsType<Product>(okResult.Value);
        Assert.Equal(product.Id, returnedProduct.Id);
    }

    [Fact]
    public async Task GetAllProducts_ReturnsOkWithList()
    {
        var product = new Product { Size = "M", Color = "Blue", Price = 29.99M, Description = "A blue medium-sized shirt" };
        await _repository.AddAsync(product);
        var result = await _controller.GetAllProducts();
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200, okResult.StatusCode);
        var products = Assert.IsType<List<Product>>(okResult.Value);
        Assert.Single(products);
    }

    [Fact]
    public async Task UpdateProduct_ExistingId_ReturnsNoContent()
    {
        var product = new Product { Size = "M", Color = "Blue", Price = 29.99M, Description = "A blue medium-sized shirt" };
        await _repository.AddAsync(product);
        var updatedProductDto = new ProductDto { Size = "L", Color = "Red", Price = 39.99M, Description = "A red large-sized shirt" };
        var result = await _controller.UpdateProduct(product.Id, updatedProductDto);
        var noContentResult = Assert.IsType<NoContentResult>(result);
        Assert.Equal(204, noContentResult.StatusCode);
        var updatedProduct = await _repository.GetByIdAsync(product.Id);
        Assert.Equal("L", updatedProduct.Size);
    }

    [Fact]
    public async Task DeleteProduct_ExistingId_ReturnsNoContent()
    {
        var product = new Product { Size = "M", Color = "Blue", Price = 29.99M, Description = "A blue medium-sized shirt" };
        await _repository.AddAsync(product);
        var result = await _controller.DeleteProduct(product.Id);
        var noContentResult = Assert.IsType<NoContentResult>(result);
        Assert.Equal(204, noContentResult.StatusCode);
        var deletedProduct = await _repository.GetByIdAsync(product.Id);
        Assert.Null(deletedProduct);
    }
}