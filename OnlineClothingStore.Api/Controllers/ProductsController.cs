using Microsoft.AspNetCore.Mvc;
using OnlineClothingStore.Core;
using OnlineClothingStore.Data;

namespace OnlineClothingStore.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _repository;

    public ProductsController(IProductRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductDto productDto)
    {
        if (productDto == null)
        {
            return BadRequest("Product data is required.");
        }
        var product = new Product
        {
            Size = productDto.Size,
            Color = productDto.Color,
            Price = productDto.Price,
            Description = productDto.Description
        };
        await _repository.AddAsync(product);
        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        var product = await _repository.GetByIdAsync(id);
        if (product == null) return NotFound();
        return Ok(product);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _repository.GetAllAsync();
        return Ok(products);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDto productDto)
    {
        if (productDto == null || id <= 0) return BadRequest("Invalid product data or ID.");
        var existingProduct = await _repository.GetByIdAsync(id);
        if (existingProduct == null) return NotFound();
        existingProduct.Size = productDto.Size;
        existingProduct.Color = productDto.Color;
        existingProduct.Price = productDto.Price;
        existingProduct.Description = productDto.Description;
        await _repository.UpdateAsync(existingProduct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var product = await _repository.GetByIdAsync(id);
        if (product == null) return NotFound();
        await _repository.DeleteAsync(id);
        return NoContent();
    }
}