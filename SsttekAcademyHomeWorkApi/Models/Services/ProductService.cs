using Microsoft.Extensions.Caching.Memory;
using SsttekAcademyHomeWorkApi.Models.Entities;
using SsttekAcademyHomeWorkApi.Models.Services;

public class ProductService : IProductService
{
    private readonly IMemoryCache _cache;
    private const string CacheKey = "Products";

    public ProductService(IMemoryCache cache)
    {
        _cache = cache;

        if (!_cache.TryGetValue(CacheKey, out List<Product> products))
        {
            products = new List<Product>();
            _cache.Set(CacheKey, products);
        }
    }

    public List<Product> GetAll()
    {
        return _cache.Get<List<Product>>(CacheKey) ?? new List<Product>();
    }

    public Product GetById(int id)
    {
        var products = GetAll();
        return products.FirstOrDefault(p => p.Id == id);
    }

    public void Create(Product product)
    {
        var products = GetAll();
        products.Add(product);
        _cache.Set(CacheKey, products);
    }

    public void Update(Product product)
    {
        var products = GetAll();
        var existing = products.FirstOrDefault(p => p.Id == product.Id);
        if (existing != null)
        {
            existing.Name = product.Name;
            existing.Price = product.Price;
            existing.Category = product.Category;
            _cache.Set(CacheKey, products);
        }
    }

    public void Delete(int id)
    {
        var products = GetAll();
        products.RemoveAll(p => p.Id == id);
        _cache.Set(CacheKey, products);
    }
}