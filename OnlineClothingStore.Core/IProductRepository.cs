namespace OnlineClothingStore.Core;

public interface IProductRepository
{
    Task AddAsync(Product product);
    Task<Product> GetByIdAsync(int id);
    Task<List<Product>> GetAllAsync();
    Task UpdateAsync(Product product);
    Task DeleteAsync(int id);
}