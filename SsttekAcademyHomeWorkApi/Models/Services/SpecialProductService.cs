using SsttekAcademyHomeWorkApi.Models.Entities;

namespace SsttekAcademyHomeWorkApi.Models.Services;

public class SpecialProductService : IProductService
{
    private readonly List<Product> _products = new List<Product>();

    public List<Product> GetAll() => _products;

    public Product GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

    public void Create(Product product) => _products.Add(product);

    public void Update(Product product)
    {
        var existing = GetById(product.Id);
        if (existing != null)
        {
            existing.Name = product.Name;
            existing.Price = product.Price;
            existing.Category = product.Category;
        }
    }

    public void Delete(int id) => _products.RemoveAll(p => p.Id == id);
}